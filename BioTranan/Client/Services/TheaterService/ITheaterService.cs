namespace BioTranan.Client.Services.TheaterService
{
    public interface ITheaterService
    {
        List<Theater> Theaters { get; set; }
        Task GetTheaters();
        Task<ServiceResponse<Theater>> GetTheater(int theaterId);
    }
}