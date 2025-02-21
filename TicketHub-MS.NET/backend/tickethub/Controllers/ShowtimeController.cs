using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tickethub.DTO;
using ticketHub.Services.Interfaces;

namespace ticketHub.Controllers
{
    [ApiController]
    [Route("showtimes")]
    //[Produces("application/json")]
    //[Consumes("application/json")]
    public class ShowtimeController : ControllerBase
    {
        private readonly IShowtimeService _showtimeService;

        public ShowtimeController(IShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        // GET: api/showtimes/movie/{movieId}
        [HttpGet("movie/{movieId}")] 
        public ActionResult<List<ShowtimeDTO>> GetShowtimesByMovie(long movieId)
        {
            var showtimes = _showtimeService.GetShowtimesByMovie(movieId);

            if (showtimes == null || showtimes.Count == 0)
                return NoContent(); // HTTP 204 No Content

            return Ok(showtimes);
        }
    }
}