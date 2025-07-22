using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AuthDbContext _context;

        public EmployeeRepository(AuthDbContext context)
        {
            _context = context;
        }

        public Task<Employee?> GetByEmailAsync(string email) =>
            _context.Employees.Include(e => e.Role).FirstOrDefaultAsync(e => e.Email == email);

        public Task<Employee?> GetByIdAsync(Guid id) =>
            _context.Employees.Include(e => e.Role).FirstOrDefaultAsync(e => e.Id == id);

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
