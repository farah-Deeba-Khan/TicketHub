using System.ComponentModel.DataAnnotations.Schema;

namespace tickethub.DTO
{
    public class MovieDTO
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public string? Status { get; set; }
        public double VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public string ReleaseDate { get; set; }
        public string? BackdropPath { get; set; }
        public string? PosterPath { get; set; }
        public string Tagline { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<MovieCastDTO> MovieCasts { get; set; }
    }
}
