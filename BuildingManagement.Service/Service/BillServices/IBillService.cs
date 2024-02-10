using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Shared;

namespace BuildingManagement.Service.Service.BillServices
{
    public interface IBillService
    {
        Task<ResponseDto<string>> AddBillsAsync(AddBillRequestDto billRequest);
    }
}
