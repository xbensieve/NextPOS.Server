using AuthService.Application.DTOs.Role;
using AuthService.Domain.Interfaces.Roles;
using AutoMapper;
using MediatR;

namespace AuthService.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;
        public GetRoleByIdQueryHandler(IRoleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _repo.GetByIdAsync(request.Id);

            return role == null ? null : _mapper.Map<RoleDto>(role);
        }
    }
}
