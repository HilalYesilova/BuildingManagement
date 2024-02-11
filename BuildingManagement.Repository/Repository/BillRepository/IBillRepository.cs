using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Repository.Repository.BillRepository;
public interface IBillRepository
{
    Task AddBillToBuildingAsync(Bill bill);
    Task AddBillToApartmentAsync(ApartmentBill bill);
}
