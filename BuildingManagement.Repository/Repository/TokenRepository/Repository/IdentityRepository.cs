using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BuildingManagement.Entity;

namespace BuildingManagement.Repository.Repository.TokenRepository.Repository
{
    public class IdentityRepository(
    UserManager<User> userManager,
    RoleManager<UserRole> roleManager,
    SignInManager<User> signInManager) : IIdentityRepository
    {
        public UserManager<User> UserManager { get; set; } = userManager;
        public RoleManager<UserRole> RoleManager { get; set; } = roleManager;
        public SignInManager<User> SignInManager { get; set; } = signInManager;


        public Task<IdentityResult> AddClaimAsync(User user, Claim claim)
        {
            return userManager.AddClaimAsync(user,
            claim);
        }

        public Task<IdentityResult> CreateUser(User user, string password)
        {
            return userManager.CreateAsync(user, password);
        }

        public async Task<bool> RoleExistsAsync(UserRole userRole)
        {
            return  await roleManager.RoleExistsAsync(userRole.Name!);
        }

        public async Task<User?> FindByIdAsync(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }
        public async Task<IdentityResult> AddToRoleAsync(User user,string userRolName)
        {
            return await userManager.AddToRoleAsync(user, userRolName);
        }

        public Task<IdentityResult> CreateRoleAsync(UserRole userRole)
        {
            return roleManager.CreateAsync(userRole);
        }
    }
}
