using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository;
using BuildingManagement.Service.Service.TokenServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BuildingManagement.Entity;
using System.Net.WebSockets;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Service.Service.ApartmentServices;
using Azure;

namespace BuildingManagement.Service.Service.TokenServices.Services;

public class IdentityService(
    IIdentityRepository identityRepository, ApartmentService apartmentService) : IIdentityService
{

    public async Task<ResponseDto<int?>> CreateUser(UserCreateRequestDto request)
    {
        var hasUser = await apartmentService.GetApartmentUserIdAsync(request.ApartmentId);
        if(hasUser == null || hasUser.Data != 0) return ResponseDto<int?>.Fail("Bu Daireye Başka Bir Kullanıcı Atanmış!");

        var User = new User
        {
            Name = request.Name,
            Surname = request.Surname,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            TcNo = request.TcNo,
            ApartmentId = request.ApartmentId
        };

        var result = await identityRepository.CreateUser(User, request.Password);

        if (!result.Succeeded)
        {
            var errorList = result.Errors.Select(x => x.Description).ToList();

            return ResponseDto<int?>.Fail(errorList);
        }

        var apartmentUser = await apartmentService.AddUserToApartment(request.ApartmentId, User);
        if (apartmentUser.AnyError) return ResponseDto<int?>.Fail("Kullanıcıyı Daireye atama işleminde sorun ile karşılaşıldı!");
        return ResponseDto<int?>.Success(User.Id);
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

    public async Task<ResponseDto<int?>> UpdateUser(UserUpdateRequestDto request)
    {
        var User = new User
        {
            Name = request.Name,
            Surname = request.Surname,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            TcNo = request.TcNo
        };
        var result = await identityRepository.UpdateUserAsync(User);
        if (!result.Succeeded)
        {
            var errorList = result.Errors.Select(x => x.Description).ToList();

            return ResponseDto<int?>.Fail(errorList);
        }
        return ResponseDto<int?>.Success(User.Id);
    }
}

