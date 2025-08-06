namespace AuthService.Application.DTOs.Role
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Permissions { get; set; }
    }
}
