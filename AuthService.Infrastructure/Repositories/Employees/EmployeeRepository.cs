using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces.Employees;
using AuthService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AuthDbContext _context;
        public EmployeeRepository(AuthDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public Task AddPasswordResetTokenAsync(PasswordResetToken token)
        {
            _context.PasswordResetTokens.Add(token);
            return _context.SaveChangesAsync();
        }

        public async Task AddRefreshToken(RefreshToken token)
        {
            _context.RefreshTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees.Include(e => e.Role)
                                           .FirstOrDefaultAsync(e => e.Email == email);
        }

        public Task<Employee?> GetByIdAsync(Guid id)
        {
            return _context.Employees.Include(e => e.Role).FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<RefreshToken?> GetRefreshTokenAsync(string token)
        {
            return _context.RefreshTokens
                .Include(t => t.Employee)
                .ThenInclude(e => e.Role)
                .FirstOrDefaultAsync(t => t.Token == token);
        }

        public Task<PasswordResetToken?> GetResetPasswordTokenAsync(string token)
        {
            return _context.PasswordResetTokens
                .Include(t => t.Employee)
                .Where(t => t.IsUsed == false)
                .FirstOrDefaultAsync(t => t.Token == token);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}