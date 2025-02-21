using System.Collections.Generic;
using System.Threading.Tasks;
using tickethub.DTO;
using tickethub.Repositories.Interfaces;
using tickethub.Services.Interfaces;

namespace tickethub.Services.Implementations
{
    public class MovieService : IMovieService  
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByTypeAsync(string type)
        {
            return await _movieRepository.GetMoviesByTypeAsync(type);
        }

        public async Task<MovieDTO> GetMoviesByIdAsync(long id)
        {
            return await _movieRepository.GetMoviesByIdAsync(id);
        }

        public async Task<MovieCastDTO> GetMovieCastByMovieIdAsync(long id)
        {
            return await _movieRepository.GetMovieCastByMovieIdAsync(id);
        }

        public async Task<IEnumerable<MovieDTO>> SearchMoviesAsync(string title)
        {
            return await _movieRepository.SearchMoviesAsync(title);
        }

        public async Task<IEnumerable<MovieDTO>> GetFilteredMoviesAsync(string status, string category, double? rating, string type)
        {
            return await _movieRepository.GetFilteredMoviesAsync(status, category, rating, type);
        }
    }
}
