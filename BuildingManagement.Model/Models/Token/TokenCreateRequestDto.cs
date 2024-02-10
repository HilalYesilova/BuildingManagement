namespace BuildingManagement.Model.Models.Token
{
    public class TokenCreateRequestDto
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? TcNo { get; set; }
        public string? PhoneNumber { get; set;}
    }
}