using AuthService.Application.DTOs.Role;
using AuthService.Domain.Interfaces.Roles;
using AutoMapper;
using MediatR;

namespace AuthService.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;
        public GetAllRolesQueryHandler(IRoleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _repo.GetAllAsync();

            var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);

            return roleDtos;
        }
    }
}
