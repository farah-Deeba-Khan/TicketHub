using tickethub.Entities;

namespace tickethub.Services.Interfaces
{
    public interface IEmailService
    {
            Task<string> SendSimpleMail(EmailDetails details);
            Task<string> SendMailWithAttachment(EmailDetails details);
    }
}
