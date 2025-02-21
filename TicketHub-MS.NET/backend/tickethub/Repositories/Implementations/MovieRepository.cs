using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tickethub.DTO;
using tickethub.Repositories.Interfaces;

namespace tickethub.Repositories.Implementations
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByTypeAsync(string type)
        {
            return await _context.Movies   
                .Where(m => m.Type == type)
                .Select(m => new MovieDTO
                {
                    Id = m.Id,
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Overview = m.Overview,
                    VoteAverage = m.VoteAverage,
                    VoteCount = m.VoteCount,
                    ReleaseDate = m.ReleaseDate,
                    PosterPath = m.PosterPath,
                    BackdropPath = m.BackdropPath,
                    Status = m.Status,
                    Category = m.Category,
                    Revenue = m.Revenue,
                    Runtime = m.Runtime,
                    Tagline = m.Tagline
                }).ToListAsync();
        }

        public async Task<MovieDTO> GetMoviesByIdAsync(long id)   
        {
            return await _context.Movies  
                .Where(m => m.Id == id)
                .Select(m => new MovieDTO
                {
                    Id = m.Id,
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Overview = m.Overview,
                    VoteAverage = m.VoteAverage,
                    VoteCount = m.VoteCount,
                    ReleaseDate = m.ReleaseDate,
                    PosterPath = m.PosterPath,
                    BackdropPath = m.BackdropPath,
                    Status = m.Status,
                    Category = m.Category,
                    Revenue = m.Revenue,
                    Runtime = m.Runtime,
                    Tagline = m.Tagline,
                    Type=m.Type
                }).FirstOrDefaultAsync();
        }

        public async Task<MovieCastDTO> GetMovieCastByMovieIdAsync(long id)
        {
            // Step 1: Get the MovieCastId from the Movie table
            var movie = await _context.Movies
                .Where(m => m.Id == id)
                .Select(m => new { m.MovieCastId }) // Fetch only MovieCastId
                .FirstOrDefaultAsync();

            if (movie == null || movie.MovieCastId == null)
            {
                return null; // Movie or MovieCastId not found
            }

            // Step 2: Fetch MovieCast using MovieCastId
            var movieCast = await _context.MovieCasts
                .Include(mc => mc.Casts) // Load associated Casts
                .Where(mc => mc.Id == movie.MovieCastId) // Fetch MovieCast by ID
                .Select(mc => new MovieCastDTO
                {
                    Director = mc.Director,
                    Writer = mc.Writer,
                    Casts = mc.Casts.Select(c => new CastDTO
                    {
                        Id = c.Id,
                        CastId=c.CastId,
                        Name = c.Name,
                        ProfilePath=c.ProfilePath
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return movieCast;
        }


        public async Task<IEnumerable<MovieDTO>> SearchMoviesAsync(string title)
        {
            return await _context.Movies
                .Where(m => m.Title.Contains(title))
                .Select(m => new MovieDTO
                {
                    Id = m.Id,
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Overview = m.Overview,
                    VoteAverage = m.VoteAverage,
                    VoteCount = m.VoteCount,
                    ReleaseDate = m.ReleaseDate,
                    PosterPath = m.PosterPath,
                    BackdropPath = m.BackdropPath,
                    Status = m.Status,
                    Category = m.Category,
                    Revenue = m.Revenue,
                    Runtime = m.Runtime,
                    Tagline = m.Tagline,
                    Type = m.Type
                }).ToListAsync();
        }

        public async Task<IEnumerable<MovieDTO>> GetFilteredMoviesAsync(string status, string category, double? rating, string type)
        {
            return await _context.Movies
                .Where(m => (status == null || m.Status == status) &&
                            (category == null || m.Category == category) &&
                            (!rating.HasValue || m.VoteAverage >= rating.Value) &&
                            (type == null || m.Type == type))
                .Select(m => new MovieDTO
                {
                    Id = m.Id,
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Overview = m.Overview,
                    VoteAverage = m.VoteAverage,
                    VoteCount = m.VoteCount,
                    ReleaseDate = m.ReleaseDate,
                    PosterPath = m.PosterPath,
                    BackdropPath = m.BackdropPath,
                    Status = m.Status,
                    Category = m.Category,
                    Revenue = m.Revenue,
                    Runtime = m.Runtime,
                    Tagline = m.Tagline
                }).ToListAsync();
        }
    }
}
