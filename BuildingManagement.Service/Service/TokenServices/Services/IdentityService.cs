using BuildingManagement.Model.Models;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository;
using BuildingManagement.Service.Service.TokenServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BuildingManagement.Entity;

namespace BuildingManagement.Service.Service.TokenServices.Services;

public class IdentityService(
    IIdentityRepository identityRepository) : IIdentityService
{

    public async Task<ResponseDto<Guid?>> CreateUser(UserCreateRequestDto request)
    {
        var User = new User
        {
            UserName = request.UserName,
            Email = request.Email
        };


        var result = await identityRepository.CreateUser(User, request.Password);

        if (!result.Succeeded)
        {
            var errorList = result.Errors.Select(x => x.Description).ToList();

            return ResponseDto<Guid?>.Fail(errorList);
        }


        var resultAsClaim = await identityRepository.AddClaimAsync(User,
            new Claim(ClaimTypes.DateOfBirth, request.BirthDate.ToShortDateString()));

        if (!resultAsClaim.Succeeded)
        {
            return ResponseDto<Guid?>.Fail(resultAsClaim.Errors.Select(x => x.Description).ToList());
        }
        return ResponseDto<Guid?>.Success(User.Id);
    }

    public async Task<ResponseDto<string>> CreateRole(RoleCreateRequestDto request)
    {
        var UserRole = new UserRole
        {
            Name = request.RoleName
        };

        var hasRole = await identityRepository.RoleExistsAsync(UserRole);


        IdentityResult? roleCreateResult = null;
        if (!hasRole)
        {
            roleCreateResult = await identityRepository.CreateRoleAsync(UserRole);
        }


        if (roleCreateResult is not null && !roleCreateResult.Succeeded)
        {
            var errorList = roleCreateResult.Errors.Select(x => x.Description).ToList();

            return ResponseDto<string>.Fail(errorList);
        }


        var hasUser = await identityRepository.FindByIdAsync(request.UserId);

        if (hasUser is null)
        {
            return ResponseDto<string>.Fail("kullanıcı bulunamadı.");
        }

        var roleAssignResult = await identityRepository.AddToRoleAsync(hasUser, UserRole.Name);

        if (!roleAssignResult.Succeeded)
        {
            var errorList = roleAssignResult.Errors.Select(x => x.Description).ToList();

            return ResponseDto<string>.Fail(errorList);
        }

        return ResponseDto<string>.Success(string.Empty);
    }
}

