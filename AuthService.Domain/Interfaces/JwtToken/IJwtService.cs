using AuthService.Domain.Entities;
using AuthService.Domain.Models.Auth;

namespace AuthService.Domain.Interfaces.JwtToken
{
    public interface IJwtService
    {
        JwtTokenResult GenerateToken(Employee employee);
        JwtTokenResult GenerateRefreshToken();
    }
}
