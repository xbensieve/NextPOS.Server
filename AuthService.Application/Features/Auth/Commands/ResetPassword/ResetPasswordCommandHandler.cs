using AuthService.Domain.Interfaces.Employees;
using AuthService.Domain.Interfaces.Password;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher _passwordHasher;
        public ResetPasswordCommandHandler(IEmployeeRepository employeeRepository, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var resetPasswordToken = await _employeeRepository.GetResetPasswordTokenAsync(request.Token);
            if (resetPasswordToken == null)
                throw new ArgumentNullException(nameof(resetPasswordToken));

            if (resetPasswordToken.ExpiresAt < DateTime.UtcNow)
            {
                throw new Exception("Token is expired.");
            }

            try
            {
                var hashedPassword = _passwordHasher.HashPassword(request.NewPassword);

                //Update account password
                resetPasswordToken.Employee.PasswordHash = hashedPassword;
                resetPasswordToken.Employee.UpdatedAt = DateTime.UtcNow;

                resetPasswordToken.IsUsed = true;
                resetPasswordToken.UsedAt = DateTime.UtcNow;

                await _employeeRepository.SaveChangesAsync();
                return Guid.NewGuid();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when reseting password: {ex.Message}");
            }

        }
    }
}
