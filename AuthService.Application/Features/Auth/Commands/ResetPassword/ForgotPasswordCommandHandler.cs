using AuthService.Application.BackgroundWorker;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces.Email;
using AuthService.Domain.Interfaces.Employees;
using MediatR;

namespace AuthService.Application.Features.Auth.Commands.ResetPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmailService _emailService;
        private readonly IBackgroundTaskQueue _taskQueue;

        public ForgotPasswordCommandHandler(
            IEmployeeRepository employeeRepository,
            IEmailService emailService,
            IBackgroundTaskQueue backgroundTaskQueue)
        {
            _employeeRepository = employeeRepository;
            _emailService = emailService;
            _taskQueue = backgroundTaskQueue;
        }

        public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByEmailAsync(request.Email);
            if (employee == null)
                throw new Exception("Employee not found");

            var token = Guid.NewGuid().ToString();

            var resetToken = new PasswordResetToken
            {
                Token = token,
                EmployeeId = employee.Id,
                IsUsed = false,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };

            await _employeeRepository.AddPasswordResetTokenAsync(resetToken);

            _taskQueue.QueueBackgroundWorkItem(async ct =>
            {
                try
                {
                    var resetLink = $"https://dressify-vesti.vercel.app/reset-password?token={token}";
                    string subject = "Reset password";
                    string htmlBody = $@"
                        <h2>Password Reset Request</h2>
                        <p>Hello <strong>{employee.Name}</strong>,</p>
                        <p>We received a request to reset your password. Please click the link below to reset it:</p>
                        <p><a href='{resetLink}'>Reset your password</a></p>
                        <p>This link will expire in 1 hour.</p>
                        <br/>
                        <p>If you did not request this, please ignore this email.</p>
                        <p>- XBensieve Support Team</p>";

                    await _emailService.SendEmailAsync(employee.Email, subject, htmlBody);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Sending reset email: {ex.Message}");
                }
            });
        }
    }
}
