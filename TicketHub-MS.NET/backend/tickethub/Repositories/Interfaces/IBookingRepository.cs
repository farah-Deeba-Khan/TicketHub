using System.Threading.Tasks;

namespace tickethub.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingById(long bookingId);   
        Task<Booking> CreateBooking(Booking booking);
        Task<bool> UpdateBookingStatus(long bookingId, string status);
    }
}

