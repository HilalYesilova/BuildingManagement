using BuildingManagement.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.AdminRepository
{
    public class DuesRepository(AppDbContext context) : IDuesRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<List<Apartment>> GetAllApartmentsAsync(List<Dues> dues)
        {
            var apartmentIds = dues.Select(d => d.ApartmentId).ToList();
            var apartments = await _context.Apartments
                                        .Where(a => apartmentIds.Contains(a.Id))
                                        .ToListAsync();
            return apartments;
        }

        public async Task AddDuesToApartments(List<Dues> dues)
        {
            await _context.Dues.AddRangeAsync(dues);
        }
    }
}
