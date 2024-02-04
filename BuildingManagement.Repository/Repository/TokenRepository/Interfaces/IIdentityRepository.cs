using System.Security.Claims;
using BuildingManagement.Entity;
using Microsoft.AspNetCore.Identity;

namespace BuildingManagement.Repository
{
    public interface IIdentityRepository
    {
        Task<IdentityResult> CreateUser(User user, string password);
        Task<IdentityResult> AddClaimAsync(User user, Claim claim);
        Task<bool> RoleExistsAsync(UserRole userRole);
        Task<User?> FindByIdAsync(string userId);
        Task<IdentityResult> AddToRoleAsync(User user, string userRolName);
        Task<IdentityResult> CreateRoleAsync(UserRole userRole);
    }
}
