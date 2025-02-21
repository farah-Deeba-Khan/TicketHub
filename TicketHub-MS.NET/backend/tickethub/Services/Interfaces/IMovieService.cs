using System.Collections.Generic;
using System.Threading.Tasks;
using tickethub.DTO;

namespace tickethub.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetMoviesByTypeAsync(string type);
        Task<MovieDTO> GetMoviesByIdAsync(long id);
        Task<MovieCastDTO> GetMovieCastByMovieIdAsync(long id);
        Task<IEnumerable<MovieDTO>> SearchMoviesAsync(string title);
        Task<IEnumerable<MovieDTO>> GetFilteredMoviesAsync(string status, string category, double? rating, string type);
    }
}
