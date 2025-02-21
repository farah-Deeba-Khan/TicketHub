using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tickethub.Repositories;
using ticketHub.Repositories.Interfaces;

namespace ticketHub.Repositories.Implementations
{
    public class ShowtimeRepository : IShowtimeRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowtimeRepository(ApplicationDbContext context) => _context = context;   

        //public List<Showtime> FindByMovieId(long movieId)
        //{
        //    return _context.Showtimes.OfType<Showtime>().Where(s => s.Movie.Id == movieId).ToList(); // Cast objects to Showtime
        //}

        public List<Showtime> FindByMovieId(long movieId)
        {
            return _context.Showtimes
                .Include(s => s.Movie)  // Ensure Movie is loaded
                .Include(s => s.Theater) // Ensure Theater is loaded
                .Where(s => s.Movie.Id == movieId)
                .ToList();
        }

    }
}