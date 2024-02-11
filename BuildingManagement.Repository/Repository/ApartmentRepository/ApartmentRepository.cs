using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Repository.Repository.ApartmentRepository;

public class ApartmentRepository(AppDbContext context) : IApartmentRepository
{
    private readonly AppDbContext _context = context;
    public async Task AddApartmentToBuildingAsync(Apartment apartment)
    {
        await _context.AddAsync(apartment);
    }

    public async Task<Building> GetBuildingInfo()
    {
        return await _context.Buildings.FirstOrDefaultAsync();
    }

    public async Task AddUserToApartmentAsync(int apartmentId, User user)
    {
        var apartment = await _context.Apartments.Where(a => a.Id == apartmentId).FirstOrDefaultAsync();
        if (apartment != null)
        {
            apartment.UserId = user.Id;
            apartment.User = user;
            _context.Update(apartment);
        }
    }

    public async Task<int?> GetApartmentUserIdAsync(int apartmentId)
    {
        int? userId = 0;
        var apartment = await _context.Apartments.Where(a => a.Id == apartmentId).FirstOrDefaultAsync();
        if (apartment != null)
        {
            userId = apartment.UserId != null ? apartment.UserId : userId;
        }
        return userId;
    }
}
