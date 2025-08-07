using AuthService.Application.DTOs.Role;
using MediatR;

namespace AuthService.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
    {
    }
}
