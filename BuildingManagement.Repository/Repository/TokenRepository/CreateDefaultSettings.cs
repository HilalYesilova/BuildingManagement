using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Entity.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Repository.Repository.TokenRepository
{
    public class CreateDefaultSettings(RoleManager<UserRole> roleManager, UserManager<User> userManager, AppDbContext context)
    {
        private readonly AppDbContext _context = context;
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
                    Name = "Hilal",
                    Surname = "Yesilova",
                    TcNo = "112233445566",
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

        public async Task CreateDefaultBuildingAsync()
        {
            var buildingName = "Papara Apt";
            var existingBuilding = await _context.Buildings
                                                .FirstOrDefaultAsync(b => b.Name == buildingName);

            if (existingBuilding == null)
            {
                var newBuilding = new Building
                {
                    Name = buildingName,
                    Address = "Istanbul"
                };

                _context.Buildings.Add(newBuilding);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CraeteDefaultPaymentTypesAsync()
        {
            var paymentTypesTable = _context.PaymentTypes.ToListAsync();
            if (paymentTypesTable == null || paymentTypesTable.Result.Count == 0)
            {
                var paymentTypes = new List<PaymentType>
                {
                    new PaymentType { Method = PaymentTypes.Dues },
                    new PaymentType { Method = PaymentTypes.ElectricityBill },
                    new PaymentType { Method = PaymentTypes.WaterBill },
                    new PaymentType { Method = PaymentTypes.NaturalGasBill }
                };

                await _context.PaymentTypes.AddRangeAsync(paymentTypes);
                await _context.SaveChangesAsync();
            }
        }
    }
}
