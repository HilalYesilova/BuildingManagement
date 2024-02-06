using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.BillService
{
    public interface IBillService
    {
        Task<ResponseDto<string>> AddBillsAsync(AddBillRequestDto billRequest);
    }
}
