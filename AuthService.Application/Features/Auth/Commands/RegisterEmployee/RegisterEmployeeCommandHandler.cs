using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces.Employees;
using AuthService.Domain.Interfaces.Password;
using AuthService.Domain.Interfaces.Roles;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;
        public RegisterEmployeeCommandHandler(IEmployeeRepository employeeRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<Guid> Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetByEmailAsync(request.Email);
            if (existingEmployee != null)
            {
                throw new InvalidOperationException($"An employee with email {request.Email} already exists.");
            }

            var role = await _roleRepository.GetByNameAsync(request.RoleName);

            if (role == null)
            {
                throw new InvalidOperationException($"Role '{request.RoleName}' does not exist.");
            }

            var newEmployee = new Employee
            {
                EmployeeCode = GenerateEmployeeCode(role.Name),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = _passwordHasher.HashPassword(request.Password),
                RoleId = role.Id,
            };

            await _employeeRepository.AddAsync(newEmployee);

            return newEmployee.Id;
        }
        private string GenerateEmployeeCode(string roleName)
        {
            var prefix = roleName.Substring(0, 3).ToUpper();
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var randomPart = Random.Shared.Next(100000, 999999).ToString();
            var generatedCode = $"{prefix}{datePart}{randomPart}";
            return generatedCode;
        }
    }
}
