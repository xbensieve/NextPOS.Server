using MediatR;

namespace AuthService.Application.Features.Auth.Commands.ResetPassword
{
    public class ForgotPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
}
