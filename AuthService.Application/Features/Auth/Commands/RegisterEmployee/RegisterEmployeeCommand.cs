using MediatR;

namespace AuthService.Application.Features.Auth.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; } = "Employee";
    }
}
