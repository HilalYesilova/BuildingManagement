using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository;
using BuildingManagement.Service.Service.TokenServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BuildingManagement.Entity;
using System.Net.WebSockets;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Model.Models.Admin;

namespace BuildingManagement.Service.Service.TokenServices.Services;

public class IdentityService(
    IIdentityRepository identityRepository) : IIdentityService
{

    public async Task<ResponseDto<Guid?>> CreateUser(UserCreateRequestDto request)
    {
        var User = new User
        {
            Name = request.Name,
            Surname = request.Surname,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            TcNo = request.TcNo,
            Apartment = new Apartment
            {
                Id = request.ApartmentId
            }
        };


        var result = await identityRepository.CreateUser(User, request.Password);

        if (!result.Succeeded)
        {
            var errorList = result.Errors.Select(x => x.Description).ToList();

            return ResponseDto<Guid?>.Fail(errorList);
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

    public async Task<ResponseDto<string>> DeleteUser(string email)
    {
        var result = await identityRepository.DeleteUserAsync(email);
        if (!result.Succeeded)
        {
            var errorList = result.Errors.Select(x => x.Description).ToList();
            return ResponseDto<string>.Fail(errorList);
        }
        return ResponseDto<string>.Success(string.Empty);
    }

    public async Task<ResponseDto<Guid?>> UpdateUser(UserCreateRequestDto request)
    {
        var User = new User
        {
            Name = request.Name,
            Surname = request.Surname,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            TcNo = request.TcNo,
            Apartment = new Apartment
            {
                Id = request.ApartmentId
            }
        };
        var result = await identityRepository.UpdateUserAsync(User);
        if (!result.Succeeded)
        {
            var errorList = result.Errors.Select(x => x.Description).ToList();

            return ResponseDto<Guid?>.Fail(errorList);
        }
        return ResponseDto<Guid?>.Success(User.Id);
    }
}

