using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterService _theaterService;

        public TheaterController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Theater>>>> GetTheaters()
        {
            var result = await _theaterService.GetTheatersAsync();
            return Ok(result);
        }

        [HttpGet("{theaterId}")]
        public async Task<ActionResult<ServiceResponse<Theater>>> GetTheater(int theaterId)
        {
            var result = await _theaterService.GetTheaterAsync(theaterId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Show>>> AddTheater(string name, int capacity)
        {
            var result = await _theaterService.AddTheaterAsync(name, capacity);
            return Ok(result);
        }

        [HttpPut("{theaterId}")]
        public async Task<ActionResult<ServiceResponse<Theater>>> UpdateTheater(int theaterId, string name, int capacity)
        {
            var result = await _theaterService.UpdateTheaterAsync(theaterId, name, capacity);
            return Ok(result);
        }

        [HttpDelete("{theaterId}")]
        public async Task<ActionResult<ServiceResponse<Theater>>> DeleteTheater(int theaterId)
        {
            var result = await _theaterService.DeleteTheaterAsync(theaterId);
            return Ok(result);
        }
    }
}