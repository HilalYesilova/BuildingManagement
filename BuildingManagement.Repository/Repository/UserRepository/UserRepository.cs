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
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<Apartment?> GetApartmentByUserId(int id)
        {
            return await _context.Apartments.Where(s => s.User.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User?> GetUserAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByPhoneAsync(string phone)
        {
            return await _context.Users.Where(u => u.PhoneNumber == phone).FirstOrDefaultAsync();
        }
        public async Task<User?> GetUserByApartmentIdAsync(int apartmentId)
        {
            return await _context.Users.Where(u => u.ApartmentId == apartmentId).FirstOrDefaultAsync();
        }
        public async Task<Apartment?> GetUserApartmentAsync(int apartmentId)
        {
            return await _context.Apartments.Where(a => a.Id == apartmentId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ApartmentBill?>> GetBillsInfoAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Apartment)
                .FirstOrDefaultAsync(u => u.Id == id);

            var bills = await _context.ApartmentBills
                .Include(ab => ab.Apartment)
                .Where(ab => ab.Apartment.Id == user.ApartmentId).ToListAsync();

            return bills;
        }

        public async Task<IEnumerable<Dues?>> GetDuesInfoAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Apartment)
                .FirstOrDefaultAsync(u => u.Id == id);
            var dues = await _context.Dues
                .Where(d => d.ApartmentId == user.ApartmentId).ToListAsync();
            return dues;
        }

        public async Task UpdateDuesAsync(Dues dues)
        {
            _context.Update(dues);
        }
        public async Task UpdateBillAsync(ApartmentBill bill)
        {
            _context.Update(bill);
        }
    }
}
