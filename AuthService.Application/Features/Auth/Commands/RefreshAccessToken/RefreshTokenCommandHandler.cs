using AuthService.Application.DTOs.Auth;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces.Employees;
using AuthService.Domain.Interfaces.JwtToken;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.RefreshAccessToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshAccessTokenCommand, LoginResultDto>
    {
        private readonly IJwtService _jwtService;
        private readonly IEmployeeRepository _employeeRepository;

        public RefreshTokenCommandHandler(IJwtService jwtService, IEmployeeRepository employeeRepository)
        {
            _jwtService = jwtService;
            _employeeRepository = employeeRepository;
        }

        public async Task<LoginResultDto> Handle(RefreshAccessTokenCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                throw new ArgumentException("Refresh token cannot be null or empty.", nameof(request.RefreshToken));
            }

            var storedToken = await _employeeRepository.GetRefreshTokenAsync(request.RefreshToken);
            if (storedToken == null || storedToken.IsRevoked || storedToken.ExpiresAt <= DateTime.UtcNow)
                throw new UnauthorizedAccessException("Invalid or expired refresh token.");

            var employee = storedToken.Employee;

            var newAccessToken = _jwtService.GenerateToken(employee);

            var newRefreshToken = _jwtService.GenerateRefreshToken();

            storedToken.IsRevoked = true;
            storedToken.RevokedAt = DateTime.UtcNow;

            var newTokenEntity = new RefreshToken
            {
                EmployeeId = employee.Id,
                Token = newRefreshToken.Token,
                ExpiresAt = newRefreshToken.ExpiresAt,
                CreatedAt = DateTime.UtcNow,
            };

            await _employeeRepository.AddRefreshToken(newTokenEntity);

            return new LoginResultDto
            {
                AccessToken = newAccessToken.Token,
                AccessTokenExpiresAt = newAccessToken.ExpiresAt,
                RefreshToken = newRefreshToken.Token,
                RefreshTokenExpiresAt = newRefreshToken.ExpiresAt,
            };

        }
    }
}
