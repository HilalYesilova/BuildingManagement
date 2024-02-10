using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BuildingManagement.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<User, UserRole, int>(options)

    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<ApartmentBill> ApartmentBills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Fluent API 

            builder.Entity<Dues>()
                .HasOne(d => d.Apartment)
                .WithMany(a => a.Dues)
                .HasForeignKey(d => d.ApartmentId);

            //builder.Entity<Payment>()
            //.HasOne(p => p.Dues)
            //.WithOne(d => d.Payment)
            //.HasForeignKey<Dues>(d => d.Id);

            builder.Entity<Payment>()
            .HasOne(p => p.Dues)
            .WithOne()
            .HasForeignKey<Payment>(d => d.DuesId)
            .OnDelete(DeleteBehavior.NoAction); // Silme işleminde kaskat ilişkiyi önlemek için NoAction kullanılır





            //builder.Entity<Payment>()
            //.HasOne(p => p.ApartmentBill)
            //.WithOne(d => d.Payment)
            //.HasForeignKey<ApartmentBill>(d => d.Id);






            //builder.Entity<Payment>()
            //    .HasOne(p => p.Apartment)
            //    .WithMany(a => a.Payments)
            //    .HasForeignKey(p => p.ApartmentId);

            builder.Entity<Payment>()
            .HasOne(p => p.Apartment)
            .WithMany() // Apartment sınıfında bir koleksiyon olmadığı için WithMany() kullanıyoruz
            .HasForeignKey(p => p.ApartmentId)
            .OnDelete(DeleteBehavior.NoAction); // Silme işleminde kaskat ilişkiyi önlemek için NoAction kullanılır

            builder.Entity<User>()
            .HasOne(u => u.Apartment)
            .WithOne(a => a.User)
            .HasForeignKey<Apartment>(a => a.UserId);

            //builder.Entity<Apartment>()
            //    .HasOne(a => a.User)
            //    .WithOne(u => u.Apartment)
            //    .HasForeignKey(a => a.UserId);

            builder.Entity<Apartment>()
            .HasOne(a => a.Building) 
            .WithMany(b => b.Apartments)
            .HasForeignKey(a => a.BuildingId);


            builder.Entity<ApartmentBill>()
                .HasOne(ab => ab.Apartment)
                .WithMany(a => a.ApartmentBills)
                .HasForeignKey(ab => ab.ApartmentId);
        }
    }

}