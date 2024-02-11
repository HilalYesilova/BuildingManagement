using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Repository.Repository.UserRepository;
public interface IUserRepository
{
    Task<User> GetUserAsync(int id);
    Task<Apartment> GetApartmentByUserId(int id);
    Task<IEnumerable<ApartmentBill?>> GetBillsInfoAsync(int id);
    Task<IEnumerable<Dues?>> GetDuesInfoAsync(int id);
    Task<User?> GetUserByPhoneAsync(string phone);
    Task<User?> GetUserByApartmentIdAsync(int apartmentId);
    Task<Apartment?> GetUserApartmentAsync(int apartmentId);
    Task UpdateDuesAsync(Dues dues);
    Task UpdateBillAsync(ApartmentBill bill);
    Task<IEnumerable<User>> GetAllUsers();
}
