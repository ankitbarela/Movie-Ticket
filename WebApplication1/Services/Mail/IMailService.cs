using WebApplication1.Model;

namespace WebApplication1.Services.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
