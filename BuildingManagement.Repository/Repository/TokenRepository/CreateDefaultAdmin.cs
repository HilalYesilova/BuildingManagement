using BuildingManagement.Entity;
using Microsoft.AspNetCore.Identity;

namespace BuildingManagement.Repository.Repository.TokenRepository
{
    public class CreateDefaultAdmin(RoleManager<UserRole> roleManager, UserManager<User> userManager)
    {
        public UserManager<User> UserManager { get; set; } = userManager;
        public RoleManager<UserRole> RoleManager { get; set; } = roleManager;
        public async Task CreateDefaultAdminAsync()
        {
            string adminRoleName = "Admin";
            if (!roleManager.RoleExistsAsync(adminRoleName).Result)
            {
                var UserRole = new UserRole
                {
                    Name = adminRoleName
                };
                roleManager.CreateAsync(UserRole).Wait();
            }

            string adminUserName = "admin@example.com";
            if (userManager.FindByEmailAsync(adminUserName).Result == null)
            {
                User adminUser = new User
                {
                    UserName = adminUserName,
                    Email = adminUserName
                };

                IdentityResult result = userManager.CreateAsync(adminUser, "Admin123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, adminRoleName).Wait();
                }
            }
        }
    }
}
