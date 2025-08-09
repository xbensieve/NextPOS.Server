using MediatR;

namespace AuthService.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Guid>
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
