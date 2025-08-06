using AuthService.Application.DTOs.Role;
using MediatR;

namespace AuthService.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQuery : IRequest<RoleDto>
    {
        public Guid Id { get; set; }
        public GetRoleByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
