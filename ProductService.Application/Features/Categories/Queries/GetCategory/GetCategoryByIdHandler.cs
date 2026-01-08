using MediatR;
using ProductService.Application.DTOs.Categories;
using ProductService.Domain.Interfaces.Categories;

namespace ProductService.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly ICategoryRepository _repo;

        public GetCategoryByIdHandler(ICategoryRepository repo) => _repo = repo;

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetByIdAsync(request.Id);
            if (entity is null) return null;

            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
            };
        }
    }
}
