using BuildingManagement.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.AdminRepository
{
    public class DuesRepository(AppDbContext _context) : IDuesRepository
    {
        public async Task<List<Apartment>> GetAllApartmentsAsync(List<Dues> dues)
        {

            return await _context.Apartments
                        .Where(a => dues.Any(d => d.ApartmentId == a.Id))
                        .ToListAsync();
        }

        public async Task AddDuesToApartments(List<Dues> dues)
        {
            await _context.Dues.AddRangeAsync(dues);
        }
    }
}
