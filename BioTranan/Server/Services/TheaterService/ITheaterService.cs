namespace BioTranan.Server.Services.TheaterService
{
    public interface ITheaterService
    {
        Task<ServiceResponse<List<Theater>>> GetTheatersAsync();
        Task<ServiceResponse<Theater>> GetTheaterAsync(int theaterId);
        Task<ServiceResponse<Theater>> AddTheaterAsync(string name, int capacity);
        Task<ServiceResponse<Theater>> UpdateTheaterAsync(int theaterId, string name, int capacity);
        Task<ServiceResponse<bool>> DeleteTheaterAsync(int theaterId);
    }
}