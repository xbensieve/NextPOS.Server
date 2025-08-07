using AuthService.Application.DTOs.Auth;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.RefreshAccessToken
{
    public class RefreshAccessTokenCommand : IRequest<LoginResultDto>
    {
        public string RefreshToken { get; set; } = default!;
    }
}
