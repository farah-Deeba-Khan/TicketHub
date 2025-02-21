using System.Net.Mail;
using System.Net;
using tickethub.Entities;
using tickethub.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace tickethub.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly string _sender;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailService(IConfiguration configuration)
        {
            _sender = configuration["EmailSettings:Sender"];
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            _smtpUsername = configuration["EmailSettings:Username"];
            _smtpPassword = configuration["EmailSettings:Password"];
        }

        public async Task<string> SendSimpleMail(EmailDetails details)
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
                        Subject = details.Subject,
                        Body = details.MsgBody,
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(details.Recipient);

                    await smtpClient.SendMailAsync(mailMessage); // ✅ Async sending
                }
                return "Mail Sent Successfully...";
            }
            catch (Exception)
            {
                return "Error while Sending Mail";
            }
        }

        public async Task<string> SendMailWithAttachment(EmailDetails details)
        {
            if (!string.IsNullOrEmpty(details.Attachment) && File.Exists(details.Attachment))
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
                            Subject = details.Subject,
                            Body = details.MsgBody,
                            IsBodyHtml = false
                        };
                        mailMessage.To.Add(details.Recipient);

                        // Adding attachment
                        mailMessage.Attachments.Add(new Attachment(details.Attachment));

                        await smtpClient.SendMailAsync(mailMessage); // ✅ Async sending
                    }
                    return "Mail Sent Successfully...";
                }
                catch (Exception)
                {
                    return "Error while Sending Mail";
                }
            }
            else
            {
                // If no attachment, send simple mail
                return await SendSimpleMail(details);
            }
        }
    }
}
