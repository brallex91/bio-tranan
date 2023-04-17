namespace BioTranan.Client.Services.TheaterService
{
    public class TheaterService : ITheaterService
    {
        private readonly HttpClient _http;

        public TheaterService(HttpClient http)
        {
            _http = http;
        }

        public List<Theater> Theaters { get; set; } = new List<Theater>();

        public async Task<ServiceResponse<Theater>> GetTheater(int theaterId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Theater>>($"api/theater/{theaterId}");
            return result;
        }

        public async Task GetTheaters()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Theater>>>("api/theater");
            if (result != null && result.Data != null)
            {
                Theaters = result.Data;
            }
        }
    }
}