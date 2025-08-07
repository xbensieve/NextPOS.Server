using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces.Roles
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(Guid id);
        Task<Role?> GetByNameAsync(string name);
    }
}
