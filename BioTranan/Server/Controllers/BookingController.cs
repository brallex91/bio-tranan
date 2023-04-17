using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Booking>>>> GetBookings()
        {
            var result = await _bookingService.GetBookingsAsync();
            return Ok(result);
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<ServiceResponse<Booking>>> GetBooking(int bookingId)
        {
            var result = await _bookingService.GetBookingAsync(bookingId);
            return Ok(result);
        }

        [HttpGet("show/{showId}")]
        public async Task<ActionResult<ServiceResponse<List<Booking>>>> GetBookingsForShow(int showId)
        {
            var result = await _bookingService.GetBookingsForShowAsync(showId);
            return Ok(result);
        }

        [HttpDelete("{bookingId}")]
        public async Task<ActionResult<ServiceResponse<Booking>>> DeleteBooking(int bookingId)
        {
            var result = await _bookingService.DeleteBookingAsync(bookingId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Booking>>> AddBooking(string customerEmail, int numberOfTickets, int showId)
        {
            var result = await _bookingService.AddBookingAsync(customerEmail, numberOfTickets, showId);
            return Ok(result);
        }

        [HttpDelete("all")]
        public async Task<ActionResult<ServiceResponse<Booking>>> DeleteAllBookings()
        {
            var result = await _bookingService.DeleteAllBookingsAsync();
            return Ok(result);
        }
    }
}