using AuthService.Application.Commands;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Services;
using MediatR;

namespace AuthService.Application.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IPasswordHasher _hasher;
        public CreateAccountHandler(IEmployeeRepository repo, IPasswordHasher hasher)
        {
            _repository = repo;
            _hasher = hasher;
        }
        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                EmployeeCode = request.EmployeeCode,
                Name = request.Name,
                Email = request.Email,
                PasswordHash = _hasher.HashPassword(request.Password),
                RoleId = request.RoleId
            };

            await _repository.AddAsync(employee);
            return employee.Id;
        }
    }
}
