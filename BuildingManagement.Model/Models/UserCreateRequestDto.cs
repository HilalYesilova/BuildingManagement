namespace BuildingManagement.Model.Models
{
    public class UserCreateRequestDto
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        public DateTime BirthDate { get; set; }
    }
}