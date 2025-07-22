using AuthService.Infrastructure.DTOs;
using MediatR;

namespace AuthService.Application.Queries
{
    public class LoginQuery : IRequest<AuthResponseDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
