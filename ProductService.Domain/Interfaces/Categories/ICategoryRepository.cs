using ProductService.Domain.Entities;
using System.Linq.Expressions;

namespace ProductService.Domain.Interfaces.Categories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Query();
        Task<IEnumerable<Category>> GetListAsync(
            string? keyword = null,
            Expression<Func<Category, bool>>? filter = null,
            Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
            int pageIndex = 1,
            int pageSize = 10);
        Task<Category?> GetByIdAsync(Guid id);
        Task AddAsync(Category entity);
        Task UpdateAsync(Category entity);
        Task SoftDeleteAsync(Guid id);
        Task HardDeleteAsync(Guid id);
    }
}
