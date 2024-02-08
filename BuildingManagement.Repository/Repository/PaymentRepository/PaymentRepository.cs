using BuildingManagement.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.PaymentRepository
{
    public class PaymentRepository(AppDbContext _context) : IPaymentRepository
    {
        public async Task<IEnumerable<Apartment>> GetApartmentsPaymentsAsync()
        {
            return await _context.Apartments
            .Include(a => a.Payments)
            .ToListAsync();

        }
    }
}
