namespace BioTranan.Client.Services.BookingService
{
    public interface IBookingService
    {
        List<Booking> Bookings { get; set; }
        Task GetBookings();
        Task<ServiceResponse<Booking>> GetBooking(int bookingId);
    }
}