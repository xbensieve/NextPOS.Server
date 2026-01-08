using MediatR;
using ProductService.Application.Common.Models;
using ProductService.Application.DTOs.Categories;

namespace ProductService.Application.Features.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery(
        string? Keyword,
        string? SortBy,
        string? SortDir,
        int PageIndex = 1,
        int PageSize = 10
    ) : IRequest<PagedResult<CategoryDto>>;
}
