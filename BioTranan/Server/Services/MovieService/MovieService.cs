namespace BioTranan.Server.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Movie>>> GetMoviesAsync()
        {
            var response = new ServiceResponse<List<Movie>>
            {
                Data = await _context.Movies.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Movie>> GetMovieAsync(int movieId)
        {
            var response = new ServiceResponse<Movie>();
            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null)
            {
                response.Success = false;
                response.Message = "Filmen finns ej i databasen.";
            }
            else
            {
                response.Data = movie;
            }

            return response;
        }

        public async Task<ServiceResponse<Movie>> AddMovieAsync(string title, string description, Genre genre, string imageUrl, int duration, string language, int ageLimit, string director, string cast, int premiereYear, int maxViews)
        {
            var response = new ServiceResponse<Movie>();

            var existingMovie = await _context.Movies.FirstOrDefaultAsync(m => m.Title == title);
            if (existingMovie != null)
            {
                response.Success = false;
                response.Message = "Filmen finns redan i databasen.";
                return response;
            }

            var movie = new Movie
            {
                Title = title,
                Description = description,
                Genre = genre,
                ImageUrl = imageUrl,
                Duration = duration,
                Language = language,
                AgeLimit = ageLimit,
                Director = director,
                Cast = cast,
                PremiereYear = premiereYear,
                MaxViews = maxViews
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            response.Data = movie;
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteMovieAsync(int movieId)
        {
            var response = new ServiceResponse<bool>();
            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null)
            {
                response.Success = false;
                response.Message = "Filmen finns ej i databasen.";
            }
            else
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                response.Data = true;
            }

            return response;
        }
    }
}