using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByEmailAsync(string email);
        Task<Employee?> GetByIdAsync(Guid id);
        Task AddAsync(Employee employee);
    }
}
