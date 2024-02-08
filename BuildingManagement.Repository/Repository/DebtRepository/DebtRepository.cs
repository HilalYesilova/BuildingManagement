using BuildingManagement.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.DebtRepository
{
    public class DebtRepository(AppDbContext _context) : IDebtRepository
    {
        public async Task<IEnumerable<Apartment>> GetAllDebtsAsync()
        {
            return await _context.Apartments.Where(a => a.OccupancyStatus).ToListAsync();
        }
    }
}
