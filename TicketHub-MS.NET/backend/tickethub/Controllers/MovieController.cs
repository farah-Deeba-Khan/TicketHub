using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using tickethub.Services.Interfaces;
using tickethub.DTO;

namespace ticketHub.Controllers
{
    [Route("movie")]
    [ApiController]  
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("type/{type}")] // Fixed the conflicting route    
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesByType(string type)
        {
            var movies = await movieService.GetMoviesByTypeAsync(type);  
            return Ok(movies);
        }

        //[HttpGet("{id}")]
        [HttpGet("id/{id}")] // Make GetMoviesById specific
        public async Task<ActionResult<MovieDTO>> GetMoviesById(long id)
        {
            var movie = await movieService.GetMoviesByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpGet("id/{id}/cast")]
        public async Task<ActionResult<MovieCastDTO>> GetMovieCastByMovieId(long id)
        {
            var movieCast = await movieService.GetMovieCastByMovieIdAsync(id);
            if (movieCast == null) return NotFound();
            return Ok(movieCast);
        }

        [HttpGet("search/title")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> SearchMovies([FromQuery] string title)
        {
            var movies = await movieService.SearchMoviesAsync(title);
            return Ok(movies);
        }

        [HttpGet("filter")] // Modified the route to avoid conflict
        public async Task<ActionResult<IEnumerable<MovieDTO>>> FilterMovies(
            [FromQuery] string? status, 
            [FromQuery] string? category,  
            [FromQuery] double? rating, 
            [FromQuery] string type) 
        {
            var movies = await movieService.GetFilteredMoviesAsync(status, category, rating, type);
            return Ok(movies);
        }
    }
}
