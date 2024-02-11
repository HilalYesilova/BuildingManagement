using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.Admin;

namespace BuildingManagement.Service.Service.TokenServices.Interfaces;
public interface IIdentityService
{
    Task<ResponseDto<int?>> CreateUser(UserCreateRequestDto request);
    Task<ResponseDto<string>> CreateRole(RoleCreateRequestDto request);
    Task<ResponseDto<string>> DeleteUser(string email);
    Task<ResponseDto<int?>> UpdateUser(UserUpdateRequestDto request);
}
