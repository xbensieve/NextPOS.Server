using AuthService.Application.DTOs.Employee;
using AuthService.Domain.Interfaces.Employees;
using AutoMapper;
using MediatR;

namespace AuthService.Application.Features.Auth.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetProfileQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
                throw new ArgumentException("Invalid Id");

            var employeeMapper = _mapper.Map<EmployeeDto>(employee);

            return employeeMapper;
        }
    }
}
