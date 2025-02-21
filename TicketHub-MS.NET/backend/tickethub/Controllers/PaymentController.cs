using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tickethub.Services.Interfaces;      

namespace tickethub.Controllers     
{
    [Route("payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromQuery] long bookingId, [FromQuery] double amount)
        {
            var orderId = await _paymentService.CreateOrder(bookingId, amount);
            if (orderId == null) return BadRequest("Payment creation failed.");
            return Ok(orderId);
        }

        [HttpPost("success")]
        public async Task<IActionResult> UpdatePaymentStatus([FromQuery] string orderId, [FromQuery] string transactionId)
        {
            await _paymentService.UpdatePaymentStatus(orderId, transactionId);
            return Ok("Payment Successful.");
        }
    }
}