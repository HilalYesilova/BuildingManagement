using BuildingManagement.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<User, UserRole, Guid>(options)

    {


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.ToTable(name: "User");
        //    });

        //    modelBuilder.Entity<IdentityRole>(entity =>
        //    {
        //        entity.ToTable(name: "Role");
        //    });
        //    modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        //    {
        //        entity.ToTable("UserRoles");
        //        //in case you chagned the TKey type
        //        //  entity.HasKey(key => new { key.UserId, key.RoleId });
        //    });

        //    modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        //    {
        //        entity.ToTable("UserClaims");
        //    });

        //    modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        //    {
        //        entity.ToTable("UserLogins");
        //        //in case you chagned the TKey type
        //        //  entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });       
        //    });

        //    modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        //    {
        //        entity.ToTable("RoleClaims");

        //    });

        //    modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        //    {
        //        entity.ToTable("UserTokens");
        //        //in case you chagned the TKey type
        //        // entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });

        //    });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
    
}