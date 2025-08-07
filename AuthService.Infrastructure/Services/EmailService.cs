using AuthService.Domain.Interfaces.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
namespace AuthService.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _email;
        private readonly string _password;

        public EmailService(IConfiguration configuration)
        {
            _email = configuration["MailSettings:Email"];
            _password = configuration["MailSettings:Password"];
        }

        public async Task SendEmailAsync(string to, string subject, string htmlContent)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("XBensieve Support Team", "no-reply@xbensieve.com"));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlContent
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_email, _password);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
