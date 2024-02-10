using BuildingManagement.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.PaymentRepository
{
    public class PaymentRepository(AppDbContext context) : IPaymentRepository
    {
        private readonly AppDbContext _context = context;
        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.AddAsync(payment);
        }

        public async Task<IEnumerable<Apartment>> GetApartmentsPaymentsAsync()
        {
            return await _context.Apartments
            .Include(a => a.Payments)
            .ToListAsync();

        }
        public async Task<IEnumerable<Payment>> GetAllPaymentDataByApartmentId(int ApartmentId, string lastYear)
        {
            return await _context.Payments.Where(p => p.ApartmentId == ApartmentId && p.Year == lastYear).ToListAsync();
        }
    }
}
