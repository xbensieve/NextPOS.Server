using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Common.Models;
using ProductService.Application.DTOs.Categories;
using ProductService.Application.Features.Categories.Commands.CreateCategory;
using ProductService.Application.Features.Categories.Queries.GetCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get category by id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var dto = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (dto is null) return NotFound(ApiResponse<object>.Fail("Category not found", 404));
            return Ok(ApiResponse<object>.Success(dto, "Category retrieved successfully"));
        }
        /// <summary>
        /// Create category
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto request)
        {
            var result = await _mediator.Send(new CreateCategoryCommand
            (
               request.Name,
               request.Description
            ));

            return (result != null) ? Ok(result) : BadRequest("Failed when creating category!");

        }
    }
}
