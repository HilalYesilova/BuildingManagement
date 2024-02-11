using AutoMapper;
using BuildingManagement.Repository;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Repository.Repository.BillRepository;

namespace BuildingManagement.Service.Service.BillServices;
public class BillService(IMapper mapper, IBillRepository billRepository, IUnitOfWork unitOfWork) : IBillService
{
    public async Task<ResponseDto<string>> AddBillsAsync(AddBillRequestDto billRequest)
    {
        var bill = new Bill
        {
            BuildingId = billRequest.BuildingId,
            Month = billRequest.Month,
            ElectricityAmount = billRequest.ElectricityAmount,
            WaterAmount = billRequest.WaterAmount,
            GasAmount = billRequest.GasAmount
        };
        var billValue = billRepository.AddBillToBuildingAsync(bill!);
        unitOfWork.Commit();
        if (billValue == null) return ResponseDto<string>.Fail(string.Empty);
        return ResponseDto<string>.Success(string.Empty);
    }
}
