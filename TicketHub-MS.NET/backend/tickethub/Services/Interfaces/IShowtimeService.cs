using System.Collections.Generic;
using tickethub.DTO;

namespace ticketHub.Services.Interfaces
{
    public interface IShowtimeService
    {
        List<ShowtimeDTO> GetShowtimesByMovie(long movieId);
    }
}
