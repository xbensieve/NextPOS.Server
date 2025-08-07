namespace AuthService.Domain.Interfaces.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string htmlContent);
    }
}
