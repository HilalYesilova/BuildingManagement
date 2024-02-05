namespace BuildingManagement.Model.Models.Admin
{
    public class RoleCreateRequestDto
    {
        public string UserId { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }
}