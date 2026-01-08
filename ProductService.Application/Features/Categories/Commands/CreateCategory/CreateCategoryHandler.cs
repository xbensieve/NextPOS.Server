using AutoMapper;
using MediatR;
using ProductService.Application.DTOs.Categories;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces.Categories;

namespace ProductService.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _cateRepo;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(ICategoryRepository cateRepo, IMapper mapper)
        {
            _cateRepo = cateRepo;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description
            };

            await _cateRepo.AddAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
