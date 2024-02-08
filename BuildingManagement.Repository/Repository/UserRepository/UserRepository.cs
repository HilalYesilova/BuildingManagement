using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.UserRepository
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public async Task<Apartment?> GetApartmentByUserId(Guid id)
        {
            return await _context.Apartments.Where(s => s.User.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ApartmentBill?>> GetBillsInfo(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Apartment)
                .FirstOrDefaultAsync(u => u.Id == id);

            var bills = await _context.ApartmentBills
                .Include(ab => ab.Apartment)
                .Where(ab => ab.Apartment.Id == user.ApartmentId).ToListAsync();
            //.Select(ab => new
            //{
            //    ab.Id,
            //    ab.Month,
            //    ab.ElectricityAmount,
            //    ab.WaterAmount,
            //    ab.GasAmount,
            //    ab.IsPaid,
            //    Type = "Bill",
            //    Amount = 0m // Fatura sorgusu olduğu için aidat tutarı 0 olacak
            //})
            //.ToListAsync();

            return bills;

        }

        public async Task<IEnumerable<Dues?>> GetDuesInfo(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Apartment)
                .FirstOrDefaultAsync(u => u.Id == id);
            var dues = await _context.Dues
                .Where(d => d.ApartmentId == user.ApartmentId).ToListAsync();
            return dues;

        }
    }
}
