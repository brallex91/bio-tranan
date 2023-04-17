namespace BioTranan.Server.Services.ShowService
{
    public interface IShowService
    {
        Task<ServiceResponse<List<Show>>> GetShowsAsync();
        Task<ServiceResponse<Show>> GetShowAsync(int showId);
        Task<ServiceResponse<List<Show>>> GetUpcomingShowsAsync();
        Task<ServiceResponse<bool>> DeleteShowAsync(int showId);
        Task<ServiceResponse<Show>> AddShowAsync(int movieId, int theaterId, DateTime showDateTime, decimal price);
    }
}