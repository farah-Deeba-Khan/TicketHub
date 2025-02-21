using Microsoft.AspNetCore.Mvc;
using tickethub.Entities;
using tickethub.Services.Interfaces;

namespace tickethub.Controllers
{
    [Route("contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactEmailService _contactEmailService;

        public ContactController(IContactEmailService contactEmailService)
        {
            _contactEmailService = contactEmailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] ContactRequest request)
        {
            try
            {
                await _contactEmailService.SendEmailAsync(request);
                return Ok("Email sent successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sending email: {ex.Message}");
            }
        }
    }
}