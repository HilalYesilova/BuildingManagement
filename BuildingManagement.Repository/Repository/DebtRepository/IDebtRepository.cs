using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Repository.Repository.DebtRepository;
public interface IDebtRepository
{
    Task<IEnumerable<Apartment>> GetAllDebtsAsync();
    Task<IEnumerable<ApartmentBill>> GetAllBillsAsync(int apartmentId);
}
