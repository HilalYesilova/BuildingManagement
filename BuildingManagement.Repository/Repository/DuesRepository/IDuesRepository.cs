using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Repository.Repository.AdminRepository;
public interface IDuesRepository
{
    Task<List<Apartment>> GetAllApartmentsAsync(List<Dues> dues);
    Task AddDuesToApartments(List<Dues> dues);
}
