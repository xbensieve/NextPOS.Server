using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces.Employees
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByEmailAsync(string email);
        Task<Employee?> GetByIdAsync(Guid id);
        Task AddAsync(Employee employee);
        Task AddRefreshToken(RefreshToken token);
        Task AddPasswordResetTokenAsync(PasswordResetToken token);
        Task<RefreshToken?> GetRefreshTokenAsync(string token);
        Task<PasswordResetToken?> GetResetPasswordTokenAsync(string token);
        Task SaveChangesAsync();
    }
}
