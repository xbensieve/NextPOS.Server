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

        public Task AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetListAsync(string? keyword = null, Expression<Func<Category, bool>>? filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task HardDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> Query()
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
