using BuildingManagement.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuildingManagement.Entity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string TcNo { get; set; } = default!;
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
    }
}