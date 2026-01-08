using AutoMapper;
using ProductService.Application.DTOs.Categories;
using ProductService.Domain.Entities;

namespace ProductService.Application.Mapping
{
    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
