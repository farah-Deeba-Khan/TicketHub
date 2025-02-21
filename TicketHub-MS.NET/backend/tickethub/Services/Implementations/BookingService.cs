using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tickethub.Repositories.Interfaces;
using tickethub.Services.Interfaces;

namespace tickethub.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> GetBookingById(long bookingId)
        {
            return await _bookingRepository.GetBookingById(bookingId);
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            booking.PaymentStatus = "PENDING";
            return await _bookingRepository.CreateBooking(booking);
        }

        public async Task<bool> ConfirmBooking(long bookingId)
        {
            return await _bookingRepository.UpdateBookingStatus(bookingId, "CONFIRMED");
        }
    }
}
