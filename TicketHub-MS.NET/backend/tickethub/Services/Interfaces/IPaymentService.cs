using System.Threading.Tasks;

namespace tickethub.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreateOrder(long bookingId, double amount);
        Task UpdatePaymentStatus(string orderId, string transactionId);
    }
}
