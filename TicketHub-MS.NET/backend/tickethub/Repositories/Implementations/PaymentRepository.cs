using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tickethub.Repositories.Interfaces;

namespace tickethub.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> GetPaymentByOrderId(string orderId)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.OrderId == orderId);
        }

        public async Task UpdatePaymentStatus(string orderId, string transactionId)
        {
            var payment = await GetPaymentByOrderId(orderId);
            if (payment != null)
            {
                payment.TransactionId = transactionId;
                payment.PaymentStatus = "SUCCESS";
                await _context.SaveChangesAsync();
            }
        }
    }
}
