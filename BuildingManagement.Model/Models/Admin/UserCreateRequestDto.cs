namespace BuildingManagement.Model.Models.Admin
{
    public class UserCreateRequestDto
    {
        public string? UserName { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? Password { get; set; }
        public string TcNo { get; set; } = default!;
        public int ApartmentId { get; set; } = default!;
    }
    public class ApartmentCreateRequestDto
    {
        public string BlockInfo { get; set; } = default!;
        public bool OccupancyStatus { get; set; }
        public string ApartmentType { get; set; } = default!;
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string OwnerOrTenant { get; set; } = default!;
        public int BuildingId { get; set; } = 1;
    }
}