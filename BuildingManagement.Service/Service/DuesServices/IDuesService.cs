using BuildingManagement.Model.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.DuesServices
{
    public interface IDuesService
    {
        Task AssignDuesAsync(AssignDuesRequestDto model);
    }
}
