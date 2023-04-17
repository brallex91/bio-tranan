namespace BioTranan.Client.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _http;

        public MovieService(HttpClient http)
        {
            _http = http;
        }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public async Task<ServiceResponse<Movie>> GetMovie(int movieId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Movie>>($"api/movie/{movieId}");
            return result;
        }

        public async Task GetMovies()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Movie>>>("api/movie");
            if (result != null && result.Data != null)
            {
                Movies = result.Data;
            }
        }
    }
}