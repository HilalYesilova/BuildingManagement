using Azure.Core;
using BuildingManagement.Service.Service.TokenServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BuildingManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Repository.Repository.TokenRepository.Repository
{
    public class TokenRepository(UserManager<User> userManager, AppDbContext context) : ITokenRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<User?> FindUserAsync(string? TcNo, string? Phone)
        {
            return await _context.Users.Where(u => u.TcNo == TcNo && u.PhoneNumber == Phone).FirstOrDefaultAsync();
        }
        public async Task<User?> FindByNameAsync(string userName)
        {
            return await userManager.FindByNameAsync(userName);
        }

        public async Task<IList<Claim>> GetClaimsAsync(User user)
        {
            return await userManager.GetClaimsAsync(user);
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await userManager.GetRolesAsync(user);
        }
    }
}
