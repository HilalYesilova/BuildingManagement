using BuildingManagement.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuildingManagement.Entity
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string TcNo { get; set; } = default!;
        public Apartment Apartment { get; set; } = default!;
    }
}