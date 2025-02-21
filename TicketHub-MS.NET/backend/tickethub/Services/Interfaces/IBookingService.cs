using tickethub.Repositories.Interfaces;

namespace tickethub.Services.Interfaces
{
    public interface IBookingService
    {
          Task<Booking> GetBookingById(long bookingId);   

          Task<Booking> CreateBooking(Booking booking);

          Task<bool> ConfirmBooking(long bookingId);
    }
}
