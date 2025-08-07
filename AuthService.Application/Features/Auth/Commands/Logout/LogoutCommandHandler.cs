using AuthService.Domain.Interfaces.Employees;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public LogoutCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var token = await _employeeRepository.GetRefreshTokenAsync(request.RefreshToken);

            if (token == null)
            {
                throw new UnauthorizedAccessException("Invalid refresh token.");
            }

            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;

            await _employeeRepository.SaveChangesAsync();
        }
    }
}
