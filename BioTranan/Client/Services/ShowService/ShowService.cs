using BioTranan.Client.Services.TheaterService;

namespace BioTranan.Client.Services.ShowService
{
    public class ShowService : IShowService
    {
        private readonly HttpClient _http;
        private readonly IMovieService _movieService;
        private readonly ITheaterService _theaterService;

        public ShowService(HttpClient http, IMovieService movieService, ITheaterService theaterService)
        {
            _http = http;
            _movieService = movieService;
            _theaterService = theaterService;
        }

        public List<Show> Shows { get; set; } = new List<Show>();

        public async Task<ServiceResponse<Show>> GetShow(int showId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Show>>($"api/show/{showId}");
            return result;
        }

        public async Task<ServiceResponse<List<Show>>> GetShows()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Show>>>("api/show/upcoming");
            if (result != null && result.Data != null)
            {
                var shows = result.Data;

                foreach (var show in shows)
                {
                    var movieResult = await _movieService.GetMovie(show.MovieId);
                    var movie = movieResult.Data;
                    if (movie != null)
                    {
                        show.Movie = movie;
                    }

                    var theaterResult = await _theaterService.GetTheater(show.TheaterId);
                    var theater = theaterResult.Data;
                    if (theater != null)
                    {
                        show.Theater = theater;
                    }
                }

                Shows = shows;
            }

            return result;
        }
    }
}