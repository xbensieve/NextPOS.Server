namespace AuthService.Application.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
