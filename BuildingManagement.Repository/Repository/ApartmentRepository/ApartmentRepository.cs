using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Repository.Repository.ApartmentRepository
{
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
                try
                {
                    apartment.UserId = user.Id;
                    apartment.User = user;
                    _context.Update(apartment);
                }
                catch (Exception e)
                {

                    throw;
                }

            }
        }
    }
}
