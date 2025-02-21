using System.Collections.Generic;
using System.Linq;
using tickethub.DTO;
using tickethub.Services;
using ticketHub.Repositories.Interfaces;
using ticketHub.Services.Interfaces;

namespace ticketHub.Services.Implementations
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly IShowtimeRepository _showtimeRepository;

        public ShowtimeService(IShowtimeRepository showtimeRepository)
        {
            _showtimeRepository = showtimeRepository;
        }

        //public List<ShowtimeDTO> GetShowtimesByMovie(long movieId)
        //{
        //    var showtimes = _showtimeRepository.FindByMovieId(movieId);
        //    return showtimes.Select(_mapper.Map<ShowtimeDTO>).ToList();
        //}

        //public List<ShowtimeDTO> GetShowtimesByMovie(long movieId)
        //{
        //    return _showtimeRepository.FindByMovieId(movieId)
        //        .Select(s => new ShowtimeDTO
        //        {
        //            Id = s.Id,
        //            Movie = new MovieDTO  // Convert Movie to MovieDTO
        //            {
        //                Id = s.Movie.Id,
        //                MovieId = s.Movie.MovieId,
        //                Title = s.Movie.Title,
        //                Overview = s.Movie.Overview,
        //                VoteAverage = s.Movie.VoteAverage,
        //                VoteCount = s.Movie.VoteCount,
        //                ReleaseDate = s.Movie.ReleaseDate,
        //                PosterPath = s.Movie.PosterPath,
        //                BackdropPath = s.Movie.BackdropPath,
        //                Status = s.Movie.Status,
        //                Category = s.Movie.Category,
        //                Revenue = s.Movie.Revenue,
        //                Runtime = s.Movie.Runtime,
        //                Tagline = s.Movie.Tagline
        //            },
        //            Theater = new TheaterDTO  // Convert Theater to TheaterDTO
        //            {
        //                Id = s.Theater.Id,
        //                Name = s.Theater.Name,
        //                Location = s.Theater.Location,
        //            },
        //            Date = s.Date,
        //            Time = s.Time,
        //            Amount = s.Amount,
        //            AvailableSeats = s.AvailableSeats
        //        }).ToList();
        //}

        public List<ShowtimeDTO> GetShowtimesByMovie(long movieId)
        {
            return _showtimeRepository.FindByMovieId(movieId)
                .Select(s => new ShowtimeDTO     
                {
                    Id = s.Id,
                    Movie = s.Movie != null ? new MovieDTO  // Check if Movie is null
                    {
                        Id = s.Movie.Id,
                        MovieId = s.Movie.MovieId,
                        Title = s.Movie.Title,
                        Overview = s.Movie.Overview,
                        VoteAverage = s.Movie.VoteAverage,
                        VoteCount = s.Movie.VoteCount,
                        ReleaseDate = s.Movie.ReleaseDate,
                        PosterPath = s.Movie.PosterPath,
                        BackdropPath = s.Movie.BackdropPath,
                        Status = s.Movie.Status,
                        Category = s.Movie.Category,
                        Revenue = s.Movie.Revenue,
                        Runtime = s.Movie.Runtime,
                        Tagline = s.Movie.Tagline
                    } : null,  // Assign null if s.Movie is null

                    Theater = s.Theater != null ? new TheaterDTO  // Check if Theater is null
                    {
                        Id = s.Theater.Id,
                        Name = s.Theater.Name,
                        Location = s.Theater.Location,
                    } : null,  // Assign null if s.Theater is null

                    Date = s.Date,
                    Time = s.Time,
                    Amount = s.Amount,
                    AvailableSeats = s.AvailableSeats
                }).ToList();
        }



    }
}