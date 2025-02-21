using System.Net.Mail;
using System.Net;
using tickethub.Entities;
using tickethub.Services.Interfaces;

namespace tickethub.Services.Implementations
{
    public class ContactEmailService : IContactEmailService
    {
        private readonly string _sender;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public ContactEmailService(IConfiguration configuration)
        {
            _sender = configuration["EmailSettings:Sender"];
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            _smtpUsername = configuration["EmailSettings:Username"];
            _smtpPassword = configuration["EmailSettings:Password"];
        }

        public async Task SendEmailAsync(ContactRequest request)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_smtpServer))
                {
                    smtpClient.Port = _smtpPort;
                    smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_sender),
                        Subject = "Thank You for Contacting Us!",
                        Body = $@"
                            <h3>Hello {request.Name},</h3>
                            <p>Thank you for reaching out! We have received your message:</p>
                            <blockquote>{request.Message}</blockquote>
                            <p>We will get back to you soon.</p><br>
                            <p>Best Regards,<br>TicketHub Support Team</p>",
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(request.Email);

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while sending email", ex);
            }
        }
    }
}
