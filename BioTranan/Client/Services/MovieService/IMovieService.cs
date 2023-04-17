namespace BioTranan.Client.Services.MovieService
{
    public interface IMovieService
    {
        List<Movie> Movies { get; set; }
        Task GetMovies();
        Task<ServiceResponse<Movie>> GetMovie(int movieId);
    }
}