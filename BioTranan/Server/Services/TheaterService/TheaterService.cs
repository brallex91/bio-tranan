namespace BioTranan.Server.Services.TheaterService
{
    public class TheaterService : ITheaterService
    {
        private readonly DataContext _context;

        public TheaterService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Theater>> GetTheaterAsync(int theaterId)
        {
            var response = new ServiceResponse<Theater>();
            var theater = await _context.Theaters.FindAsync(theaterId);
            if (theater == null)
            {
                response.Success = false;
                response.Message = "Salongen finns ej i databasen.";
            }
            else
            {
                response.Data = theater;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Theater>>> GetTheatersAsync()
        {
            var response = new ServiceResponse<List<Theater>>
            {
                Data = await _context.Theaters.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Theater>> AddTheaterAsync(string name, int capacity)
        {
            var response = new ServiceResponse<Theater>();

            var existingTheater = await _context.Theaters.FirstOrDefaultAsync(m => m.Name == name);
            if (existingTheater != null)
            {
                response.Success = false;
                response.Message = "Salongen finns redan i databasen.";
                return response;
            }

            var theater = new Theater
            {
                Name = name,
                Capacity = capacity
            };

            await _context.Theaters.AddAsync(theater);
            await _context.SaveChangesAsync();

            response.Data = theater;
            return response;
        }

        public async Task<ServiceResponse<Theater>> UpdateTheaterAsync(int theaterId, string name, int capacity)
        {
            var response = new ServiceResponse<Theater>();
            var theater = await _context.Theaters.FindAsync(theaterId);
            if (theater == null)
            {
                response.Success = false;
                response.Message = "Salongen finns ej i databasen.";
                return response;
            }

            var oldCapacity = theater.Capacity;

            theater.Name = name;
            theater.Capacity = capacity;

            _context.Theaters.Update(theater);

            var showsToUpdate = await _context.Shows.Where(s => s.TheaterId == theaterId).ToListAsync();
            foreach (var show in showsToUpdate)
            {
                var capacityDifference = capacity - oldCapacity;
                show.AvalibleTickets += capacityDifference;
                _context.Shows.Update(show);
            }

            await _context.SaveChangesAsync();

            response.Data = theater;
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteTheaterAsync(int theaterId)
        {
            var response = new ServiceResponse<bool>();
            var theater = await _context.Theaters.FindAsync(theaterId);
            if (theater == null)
            {
                response.Success = false;
                response.Message = "Salongen finns ej i databasen.";
            }
            else
            {
                _context.Theaters.Remove(theater);
                await _context.SaveChangesAsync();
                response.Data = true;
            }

            return response;
        }
    }
}