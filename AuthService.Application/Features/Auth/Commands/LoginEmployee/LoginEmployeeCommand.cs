using AuthService.Application.DTOs.Auth;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.LoginEmployee
{
    public class LoginEmployeeCommand : IRequest<LoginResultDto>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
