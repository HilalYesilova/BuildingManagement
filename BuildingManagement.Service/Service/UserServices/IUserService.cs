using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.UserServices
{
    public interface IUserService
    {
        Task<ResponseDto<IEnumerable<UserDebtAndDuesInfoResponse>>> GetUserDebtAndDuesInfo(Guid id);
    }
}
