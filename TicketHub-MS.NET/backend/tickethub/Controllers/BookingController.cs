//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System;
//using tickethub.Services.Interfaces;
//using ticketHub.DTO;

//namespace ticketHub.Controllers
//{
//    [ApiController]
//    [Route("bookings")]
//    public class BookingController : ControllerBase
//    {
//        private readonly IBookingService _bookingService;

//        public BookingController(IBookingService bookingService)
//        {
//            _bookingService = bookingService;
//        }

//        // POST: api/bookings/create
//        [HttpPost("create")]
//        public async Task<IActionResult> CreateBooking([FromBody] BookingDTO bookingRequest)
//        {
//            if (bookingRequest == null)
//                return BadRequest("Invalid booking request");

//            Booking savedBooking = await List.Run(() => _bookingService.CreateBooking(bookingRequest));
//            return Ok(new { BookingId = savedBooking.Id });
//        }

//        // GET: api/bookings/getAllUsers
//        [HttpGet("getAllUsers")]
//        public IActionResult GetAllBookings()
//        {
//            Console.WriteLine("Fetching all bookings");
//            List<TicketHub.Services.Interfaces.BookingResponseDTO> bookings = _bookingService.GetAllBookings();

//            if (bookings == null || bookings.Count == 0)
//                return NoContent();

//            return Ok(bookings);
//        }

//        // DELETE: api/bookings/deleteUser/{bookingId}
//        [HttpDelete("deleteUser/{bookingId}")]
//        public IActionResult DeleteBookingDetails(long bookingId)
//        {
//            Console.WriteLine($"Deleting booking with ID: {bookingId}");
//            bool isDeleted = _bookingService.DeleteBookingDetails(bookingId);

//            if (!isDeleted)
//                return NotFound($"Booking with ID {bookingId} not found");

//            return Ok(new { Message = "Booking deleted successfully" });
//        }

//        private class BookingResponseDTO
//        {
//        }
//    }
//}