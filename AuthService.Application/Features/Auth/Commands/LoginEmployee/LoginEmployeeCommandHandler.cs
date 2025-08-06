using AuthService.Application.DTOs.Auth;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces.Employees;
using AuthService.Domain.Interfaces.JwtToken;
using AuthService.Domain.Interfaces.Password;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.LoginEmployee
{
    public class LoginEmployeeCommandHandler : IRequestHandler<LoginEmployeeCommand, LoginResultDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        public LoginEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            IJwtService jwtService,
            IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }
        public async Task<LoginResultDto> Handle(LoginEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByEmailAsync(request.Email);

            if (employee == null || !_passwordHasher.VerifyPassword(request.Password, employee.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");


            var accessToken = _jwtService.GenerateToken(employee);
            var refreshToken = _jwtService.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                EmployeeId = employee.Id,
                Token = refreshToken.Token,
                ExpiresAt = refreshToken.ExpiresAt,
            };

            await _employeeRepository.AddRefreshToken(refreshTokenEntity);

            return new LoginResultDto
            {
                AccessToken = accessToken.Token,
                AccessTokenExpiresAt = accessToken.ExpiresAt,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiresAt = refreshToken.ExpiresAt,
            };
        }
    }
}
