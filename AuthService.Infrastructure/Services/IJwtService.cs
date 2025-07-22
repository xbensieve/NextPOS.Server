using AuthService.Domain.Entities;
using AuthService.Infrastructure.DTOs;

namespace AuthService.Infrastructure.Services
{
    public interface IJwtService
    {
        AuthResponseDto GenerateToken(Employee user);
    }
}
