namespace BioTranan.Server.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;

        public BookingService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Booking>> GetBookingAsync(int bookingId)
        {
            var response = new ServiceResponse<Booking>();
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                response.Success = false;
                response.Message = "Bokningen finns ej i databasen.";
            }
            else
            {
                response.Data = booking;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Booking>>> GetBookingsAsync()
        {
            var response = new ServiceResponse<List<Booking>>
            {
                Data = await _context.Bookings.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Booking>>> GetBookingsForShowAsync(int showId)
        {
            var response = new ServiceResponse<List<Booking>>();
            var bookings = await _context.Bookings.Where(b => b.Show.Id == showId).ToListAsync();
            if (!bookings.Any())
            {
                response.Success = false;
                response.Message = "Det finns inga bokningar för den angivna föreställningen.";
            }
            else
            {
                response.Data = bookings;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBookingAsync(int bookingId)
        {
            var response = new ServiceResponse<bool>();
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                response.Success = false;
                response.Message = "Bokningen finns ej i databasen.";
            }
            else
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                response.Data = true;
            }

            return response;
        }

        public async Task<ServiceResponse<Booking>> AddBookingAsync(string customerEmail, int numberOfTickets, int showId)
        {
            var response = new ServiceResponse<Booking>();

            var show = await _context.Shows.FindAsync(showId);
            if (show == null)
            {
                response.Success = false;
                response.Message = "Föreställningen finns ej i databasen.";
                return response;
            }

            if (numberOfTickets > show.AvalibleTickets)
            {
                response.Success = false;
                response.Message = "Det finns inte tillräckligt med lediga biljetter för att boka så många.";
                return response;
            }

            show.AvalibleTickets -= numberOfTickets;

            var newBooking = new Booking(customerEmail, numberOfTickets, show);
            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            response.Data = newBooking;

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteAllBookingsAsync()
        {
            var response = new ServiceResponse<bool>();
            var bookings = await _context.Bookings.ToListAsync();
            if (!bookings.Any())
            {
                response.Success = false;
                response.Message = "Det finns inga bokningar i databasen.";
            }
            else
            {
                _context.Bookings.RemoveRange(bookings);
                await _context.SaveChangesAsync();
                response.Data = true;
            }

            return response;
        }
    }
}