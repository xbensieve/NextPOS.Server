using FluentValidation;

namespace AuthService.Application.Features.Auth.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommandValidator : AbstractValidator<RegisterEmployeeCommand>
    {
        public RegisterEmployeeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(255).WithMessage("Email must not exceed 255 characters.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.RoleName)
                .Must(r => !string.Equals(r, "Admin", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Cannot register an employee with the Admin role directly. Please use the Admin registration process.");
        }
    }
}
