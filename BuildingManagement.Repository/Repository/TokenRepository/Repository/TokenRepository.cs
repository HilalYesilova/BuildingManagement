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

namespace BuildingManagement.Repository.Repository.TokenRepository.Repository
{
    public class TokenRepository(UserManager<User> userManager) : ITokenRepository
    {
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
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
