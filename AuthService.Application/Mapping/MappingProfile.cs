using AuthService.Application.DTOs;
using AuthService.Domain.Entities;
using AutoMapper;

namespace AuthService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
