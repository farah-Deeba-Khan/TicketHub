//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//[Table("movies")]
//public class Movie : BaseEntity
//{
//    public long MovieId { get; set; }

//    [Required]
//    [Column(TypeName = "text")]
//    //[Index(IsUnique = true)]
//    public string Title { get; set; }

//    [Column(TypeName = "text")]
//    public string Overview { get; set; }

//    public double VoteAverage { get; set; }

//    public int VoteCount { get; set; }

//    public string ReleaseDate { get; set; }

//    public string BackdropPath { get; set; }

//    public string PosterPath { get; set; }

//    [MaxLength(30)]
//    public string Status { get; set; }

//    [Column(TypeName = "text")]
//    public string Tagline { get; set; }

//    public int Revenue { get; set; }

//    public int Runtime { get; set; }

//    [MaxLength(30)]
//    public string Type { get; set; }

//    [ForeignKey("MovieCast")]
//    public int MovieCastId { get; set; }
//    public MovieCast MovieCasts { get; set; }
//}

//using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("movies")]
public class Movie : BaseEntity
{
    [Column("movie_id")]
    public long MovieId { get; set; }

    [Column("title")]
    [Required]
    public string Title { get; set; }

    [Column("overview")]
    [Required]
    public string Overview { get; set; }

    [Column("vote_average")]
    public double VoteAverage { get; set; }

    [Column("vote_count")]
    public int VoteCount { get; set; }

    [Column("release_date")]
    public string ReleaseDate { get; set; }

    [Column("backdrop_path")]
    public string? BackdropPath { get; set; }

    [Column("poster_path")]
    public string? PosterPath { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("tagline")]
    public string Tagline { get; set; }

    [Column("revenue")]
    public int Revenue { get; set; }

    [Column("runtime")]
    public int Runtime { get; set; }

    [Column("type")]
    public string Type { get; set; }

    [ForeignKey("MovieCast")]
    //public int MovieCastId { get; set; } // Foreign key property
    public long MovieCastId { get; set; }

    public virtual MovieCast MovieCasts { get; set; } // Navigation property

    public Movie() { }

    public Movie(long movieId, string title, string overview, double voteAverage, int voteCount,
                 string releaseDate, string backdropPath, string posterPath, string status,
                 string category, string tagline, int revenue, int runtime, string type, int movieCastId)
    {
        MovieId = movieId;
        Title = title;
        Overview = overview;
        VoteAverage = voteAverage;
        VoteCount = voteCount;
        ReleaseDate = releaseDate;
        BackdropPath = backdropPath;
        PosterPath = posterPath;
        Status = status;
        Category = category;
        Tagline = tagline;
        Revenue = revenue;
        Runtime = runtime;
        Type = type;
        MovieCastId = movieCastId;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Title: {Title}, ReleaseDate: {ReleaseDate}, VoteAverage: {VoteAverage}, Category: {Category}";
    }
}
