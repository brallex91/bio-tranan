using Microsoft.AspNetCore.Mvc;


namespace BioTranan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Show>>>> GetShows()
        {
            var result = await _showService.GetShowsAsync();
            return Ok(result);
        }

        [HttpGet("{showId}")]
        public async Task<ActionResult<ServiceResponse<Show>>> GetShow(int showId)
        {
            var result = await _showService.GetShowAsync(showId);
            return Ok(result);
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<ServiceResponse<List<Show>>>> GetUpcomingShows()
        {
            var result = await _showService.GetUpcomingShowsAsync();
            return Ok(result);
        }

        [HttpDelete("{showId}")]
        public async Task<ActionResult<ServiceResponse<Show>>> DeleteShow(int showId)
        {
            var result = await _showService.DeleteShowAsync(showId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Show>>> AddShow(int movieId, int theaterId, DateTime showDateTime, decimal price)
        {
            var result = await _showService.AddShowAsync(movieId, theaterId, showDateTime, price);
            return Ok(result);
        }
    }
}