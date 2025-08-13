using AuthService.Application.DTOs.Employee;
using AuthService.Application.DTOs.Role;
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

            CreateMap<Role, RoleDto>();
        }
    }
}
