using AuthService.Application.DTOs;
using MediatR;

namespace AuthService.Application.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public Guid Id { get; set; }
    }
}
