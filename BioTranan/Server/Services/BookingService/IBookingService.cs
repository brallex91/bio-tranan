namespace BioTranan.Server.Services.BookingService
{
    public interface IBookingService
    {
        Task<ServiceResponse<List<Booking>>> GetBookingsAsync();
        Task<ServiceResponse<Booking>> GetBookingAsync(int bookingId);
        Task<ServiceResponse<List<Booking>>> GetBookingsForShowAsync(int showId);
        Task<ServiceResponse<bool>> DeleteBookingAsync(int bookingId);
        Task<ServiceResponse<Booking>> AddBookingAsync(string customerEmail, int numberOfTickets, int showId);
        Task<ServiceResponse<bool>> DeleteAllBookingsAsync();
    }
}