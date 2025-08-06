using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces.Employees
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByEmailAsync(string email);
        Task AddAsync(Employee employee);
        Task AddRefreshToken(RefreshToken token);
    }
}
