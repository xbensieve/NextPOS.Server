using MediatR;
using ProductService.Application.DTOs.Categories;

namespace ProductService.Application.Features.Categories.Queries.GetCategory
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto?>;
}
