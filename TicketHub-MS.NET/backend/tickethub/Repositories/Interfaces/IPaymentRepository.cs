using System.Threading.Tasks;

namespace tickethub.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> GetPaymentByOrderId(string orderId);
        Task UpdatePaymentStatus(string orderId, string transactionId);
    }
}
