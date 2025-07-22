using AuthService.Application.Queries;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.DTOs;
using AuthService.Infrastructure.Services;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, AuthResponseDto>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtService _jwtService;

        public LoginHandler(IEmployeeRepository repo, IPasswordHasher hasher, IJwtService jwtService)
        {
            _repository = repo;
            _hasher = hasher;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmailAsync(request.Email)
                       ?? throw new Exception("Invalid credentials");

            if (!_hasher.VerifyPassword(user.PasswordHash, request.Password))
                throw new Exception("Invalid credentials");

            return _jwtService.GenerateToken(user);
        }
    }
}
