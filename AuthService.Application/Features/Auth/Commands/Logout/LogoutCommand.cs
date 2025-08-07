using MediatR;

namespace AuthService.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommand : IRequest
    {
        public string RefreshToken { get; set; } = default!;
    }
}
