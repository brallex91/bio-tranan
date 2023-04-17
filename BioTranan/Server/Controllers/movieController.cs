using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetMovies()
        {
            var result = await _movieService.GetMoviesAsync();
            return Ok(result);
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> GetMovie(int movieId)
        {
            var result = await _movieService.GetMovieAsync(movieId);
            return Ok(result);
        }

        [HttpDelete("{movieId}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> DeleteMovie(int movieId)
        {
            var result = await _movieService.DeleteMovieAsync(movieId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Movie>>> AddMovie(string title, string description, Genre genre, string imageUrl, int duration, string language, int ageLimit, string director, string cast, int premiereYear, int maxViews)
        {
            var result = await _movieService.AddMovieAsync(title, description, genre, imageUrl, duration, language, ageLimit, director, cast, premiereYear, maxViews);
            return Ok(result);
        }
    }
}