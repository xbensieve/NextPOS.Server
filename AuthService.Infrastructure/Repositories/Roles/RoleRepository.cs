using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces.Roles;
using AuthService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuthDbContext _context;
        public RoleRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync() => await _context.Roles.AsNoTracking().ToListAsync();

        public async Task<Role?> GetByIdAsync(Guid id) => await _context.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);

    }
}
