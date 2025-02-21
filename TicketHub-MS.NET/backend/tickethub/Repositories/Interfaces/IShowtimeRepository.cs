using System;
using System.Collections.Generic;

namespace ticketHub.Repositories.Interfaces
{
    public interface IShowtimeRepository
    {
        List<Showtime> FindByMovieId(long movieId);
    }
}