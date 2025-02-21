using System;
using System.Threading.Tasks;
using Razorpay.Api;
using Microsoft.Extensions.Configuration;
using tickethub.Repositories.Interfaces;
using tickethub.Services.Interfaces;

namespace tickethub.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly string _keyId;
        private readonly string _keySecret;

        public PaymentService(IPaymentRepository paymentRepository, IBookingRepository bookingRepository, IConfiguration configuration)
        {
            _paymentRepository = paymentRepository;
            _bookingRepository = bookingRepository;
            _keyId = configuration["Razorpay:KeyId"];
            _keySecret = configuration["Razorpay:KeySecret"];  
        }

        public async Task<string> CreateOrder(long bookingId, double amount)
        {
            try
            {
                var client = new RazorpayClient(_keyId, _keySecret);

                var options = new Dictionary<string, object>
                {
                    { "amount", (int)(amount * 100) }, // Convert amount to paisa
                    { "currency", "INR" },
                    { "payment_capture", 1 }
                };

                Order order = client.Order.Create(options);

                var booking = await _bookingRepository.GetBookingById(bookingId);
                if (booking != null)
                {
                    var payment = new Payment
                    {
                        BookingId = bookingId,
                        Amount = amount,
                        PaymentDate = DateTime.UtcNow,
                        PaymentMethod = "RAZORPAY",
                        PaymentStatus = "PENDING",
                        OrderId = order["id"].ToString(),
                        TransactionId = ""
                    };

                    await _paymentRepository.CreatePayment(payment);
                }

                return order["id"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Payment Creation Failed: " + ex.Message);
                return null;
            }
        }

        public async Task UpdatePaymentStatus(string orderId, string transactionId)
        {
            await _paymentRepository.UpdatePaymentStatus(orderId, transactionId);
        }
    }
}
