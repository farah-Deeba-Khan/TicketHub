using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tickethub.Repositories.Interfaces;

namespace tickethub.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> GetBookingById(long bookingId)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> UpdateBookingStatus(long bookingId, string status)
        {
            var booking = await GetBookingById(bookingId);
            if (booking != null)
            {
                booking.PaymentStatus = status; 
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
