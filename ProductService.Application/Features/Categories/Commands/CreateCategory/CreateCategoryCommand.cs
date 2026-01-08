using MediatR;
using ProductService.Application.DTOs.Categories;

namespace ProductService.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Name, string? Description) : IRequest<CategoryDto>;

}
