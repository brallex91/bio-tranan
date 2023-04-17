namespace BioTranan.Client.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _http;

        public BookingService(HttpClient http)
        {
            _http = http;
        }

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public async Task<ServiceResponse<Booking>> GetBooking(int bookingId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Booking>>($"api/booking/{bookingId}");
            return result;
        }

        public async Task GetBookings()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Booking>>>("api/booking");
            if (result != null && result.Data != null)
            {
                Bookings = result.Data;
            }
        }
    }
}