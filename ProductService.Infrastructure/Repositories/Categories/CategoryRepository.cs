using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces.Categories;
using ProductService.Infrastructure.Data;
using System.Linq.Expressions;

namespace ProductService.Infrastructure.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _dbContext;
        public CategoryRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Category entity)
        {
            _dbContext.Categories.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Category?> GetByIdAsync(Guid id) => await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        public async Task<IEnumerable<Category>> GetListAsync(
            string? keyword = null,
            Expression<Func<Category, bool>>? filter = null,
            Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
            int pageIndex = 1, int pageSize = 10)
        {
            IQueryable<Category> query = _dbContext.Categories.Where(c => !c.IsDeleted);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c =>
                    c.Name.Contains(keyword) ||
                    (c.Description != null && c.Description.Contains(keyword)));
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                query = query.OrderBy(c => c.CreatedAt);
            }

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return await query.AsNoTracking().ToListAsync();
        }
        public async Task HardDeleteAsync(Guid id)
        {
            await _dbContext.Categories
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
        }
        public IQueryable<Category> Query()
        {
            return _dbContext.Categories.AsNoTracking();
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Categories
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.IsDeleted, true)
                .SetProperty(c => c.UpdatedAt, DateTime.UtcNow));
        }
        public async Task UpdateAsync(Category entity)
        {
            _dbContext.Categories.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
