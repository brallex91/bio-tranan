namespace BioTranan.Server.Services.ShowService
{
    public class ShowService : IShowService
    {
        private readonly DataContext _context;

        public ShowService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Show>> GetShowAsync(int showId)
        {
            var response = new ServiceResponse<Show>();
            var show = await _context.Shows.FindAsync(showId);
            if (show == null)
            {
                response.Success = false;
                response.Message = "Föreställningen finns ej i databasen.";
            }
            else
            {
                response.Data = show;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Show>>> GetShowsAsync()
        {
            var response = new ServiceResponse<List<Show>>
            {
                Data = await _context.Shows.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Show>>> GetUpcomingShowsAsync()
        {
            var response = new ServiceResponse<List<Show>>();

            var shows = await _context.Shows
                .Where(s => s.ShowDateTime > DateTime.UtcNow)
                .ToListAsync();

            response.Data = shows;

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteShowAsync(int showId)
        {
            var response = new ServiceResponse<bool>();
            var show = await _context.Shows.FindAsync(showId);
            if (show == null)
            {
                response.Success = false;
                response.Message = "Föreställningen finns ej i databasen.";
            }
            else
            {
                _context.Shows.Remove(show);
                await _context.SaveChangesAsync();
                response.Data = true;
            }

            return response;
        }

        public async Task<ServiceResponse<Show>> AddShowAsync(int movieId, int theaterId, DateTime showDateTime, decimal price)
        {
            var response = new ServiceResponse<Show>();

            var theater = await _context.Theaters.FindAsync(theaterId);
            if (theater == null)
            {
                response.Success = false;
                response.Message = "Salongen finns ej i databasen.";
                return response;
            }

            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null)
            {
                response.Success = false;
                response.Message = "Filmen finns ej i databasen.";
                return response;
            }

            if (movie.ViewCount >= movie.MaxViews)
            {
                response.Success = false;
                response.Message = "Max antal visningar har redan uppnåtts för denna film.";
                return response;
            }

            var existingShow = await _context.Shows.FirstOrDefaultAsync(s => s.TheaterId == theaterId && s.ShowDateTime == showDateTime);
            if (existingShow != null)
            {
                response.Success = false;
                response.Message = "Salongen har redan en Föreställning inbokad vid den tiden.";
                return response;
            }

            var showEndTime = showDateTime.AddMinutes(movie.Duration);

            var overlappingShows = await _context.Shows
                .Where(s => s.TheaterId == theaterId && s.ShowDateTime <= showEndTime && s.ShowDateTime.AddMinutes(s.Movie.Duration) > showDateTime)
                .ToListAsync();

            if (overlappingShows.Count > 0)
            {
                response.Success = false;
                response.Message = "Salongen har redan en Föreställning inbokad vid den tiden.";
                return response;
            }

            var newShow = new Show(showDateTime, price, theater, movie);

            movie.ViewCount += 1;

            await _context.Shows.AddAsync(newShow);
            await _context.SaveChangesAsync();

            response.Data = newShow;

            return response;
        }
    }
}