using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<User, UserRole, Guid>(options)

    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Dues> Dues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Dues>()
                .HasOne(d => d.Apartment)
                .WithMany(a => a.Dues)
                .HasForeignKey(d => d.ApartmentId);


            builder.Entity<Dues>()
                .HasOne(d => d.Payment)
                .WithOne(p => p.Dues)
                .HasForeignKey<Dues>(d => d.PaymentId);
        }
    }

}