using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Repository.Repository.ApartmentRepository;

public interface IApartmentRepository
{
    Task AddApartmentToBuildingAsync(Apartment apartment);
    Task<Building> GetBuildingInfo();
    Task AddUserToApartmentAsync(int apartmentId, User user);
    Task<int?> GetApartmentUserIdAsync(int apartmentId);
}
