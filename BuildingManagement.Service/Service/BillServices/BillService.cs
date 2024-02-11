using AutoMapper;
using BuildingManagement.Repository;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Repository.Repository.BillRepository;
using BuildingManagement.Repository.Repository.ApartmentRepository;

namespace BuildingManagement.Service.Service.BillServices;
public class BillService(IMapper mapper, IBillRepository billRepository, IUnitOfWork unitOfWork, IApartmentRepository apartmentRepository) : IBillService
{
    public async Task<ResponseDto<string>> AddBillsAsync(AddBillRequestDto billRequest)
    {
        using var transaction = unitOfWork.BeginTransaction();
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

        var apartments = await apartmentRepository.GetAllAsync();

        int occupiedApartmentCount = apartments.Count(ap => ap.OccupancyStatus == true);

        if (occupiedApartmentCount > 0)
        {
            decimal electricityPerApartment = bill.ElectricityAmount / occupiedApartmentCount;
            decimal waterPerApartment = bill.WaterAmount / occupiedApartmentCount;
            decimal gasPerApartment = bill.GasAmount / occupiedApartmentCount;

            var occupiedApartmentIds = apartments
                .Where(ap => ap.OccupancyStatus == true)
                .Select(ap => ap.Id)
                .ToList();

            foreach (var apartmentId in occupiedApartmentIds)
            {
                var apartmentBill = new ApartmentBill
                {
                    ApartmentId = apartmentId,
                    Month = billRequest.Month.Month.ToString(),
                    Year = billRequest.Month.Year.ToString(),
                    ElectricityAmount = electricityPerApartment,
                    WaterAmount = waterPerApartment,
                    GasAmount = gasPerApartment,
                    IsPaid = false
                };
                billRepository.AddBillToApartmentAsync(apartmentBill);
            }
            unitOfWork.Commit();
        }
        transaction.Commit();
        if (billValue == null) return ResponseDto<string>.Fail(string.Empty);
        return ResponseDto<string>.Success(string.Empty);
    }



}
