using Microsoft.AspNetCore.Mvc;
using tickethub.Entities;
using tickethub.Services.Interfaces;

namespace tickethub.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // Sending a simple email
        [HttpPost("sendMail")]
        public IActionResult SendMail([FromBody] EmailDetails details)
        {
            var status = _emailService.SendSimpleMail(details);
            return Ok(status);
        }

        // Sending an email with attachment
        [HttpPost("sendMailWithAttachment")]
        public IActionResult SendMailWithAttachment([FromBody] EmailDetails details)
        {
            var status = _emailService.SendMailWithAttachment(details);
            return Ok(status);
        }
    }
}

