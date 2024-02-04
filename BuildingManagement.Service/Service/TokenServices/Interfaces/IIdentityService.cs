using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.TokenServices.Interfaces
{
    public interface IIdentityService
    {
        Task<ResponseDto<Guid?>> CreateUser(UserCreateRequestDto request);
        Task<ResponseDto<string>> CreateRole(RoleCreateRequestDto request);
    }
}
