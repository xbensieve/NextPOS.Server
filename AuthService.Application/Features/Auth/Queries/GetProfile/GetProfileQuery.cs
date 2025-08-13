using AuthService.Application.DTOs.Employee;
using MediatR;

namespace AuthService.Application.Features.Auth.Queries.GetProfile
{
    public class GetProfileQuery : IRequest<EmployeeDto>
    {
        public Guid Id { get; set; }
    }
}
