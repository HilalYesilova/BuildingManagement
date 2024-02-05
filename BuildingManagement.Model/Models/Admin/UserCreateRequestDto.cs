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
}