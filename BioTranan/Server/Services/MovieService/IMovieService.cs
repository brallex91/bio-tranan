namespace BioTranan.Server.Services.MovieService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetMoviesAsync();
        Task<ServiceResponse<Movie>> GetMovieAsync(int movieId);
        Task<ServiceResponse<bool>> DeleteMovieAsync(int movieId);
        Task<ServiceResponse<Movie>> AddMovieAsync(string title, string description, Genre genre, string imageUrl, int duration, string language, int ageLimit, string director, string cast, int premiereYear, int maxViews);
    }
}