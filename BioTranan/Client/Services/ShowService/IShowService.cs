namespace BioTranan.Client.Services.ShowService
{
    public interface IShowService
    {
        List<Show> Shows { get; set; }
        Task<ServiceResponse<List<Show>>> GetShows();
        Task<ServiceResponse<Show>> GetShow(int showId);
    }
}