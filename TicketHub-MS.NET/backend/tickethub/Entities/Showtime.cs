using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Showtimes")]
public class Showtime : BaseEntity
{
    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("time")]
    public TimeOnly Time { get; set; }

    [Column("available_seats")]
    public int AvailableSeats { get; set; }

    [Column("movieId")]
    [ForeignKey("Movie")]
    //public int MovieId { get; set; }
    public long MovieId { get; set; }

    [Column("movie")]
    public Movie Movie { get; set; }

    [ForeignKey("Theater")]
    //public int TheaterId { get; set; }
    public long TheaterId { get; set; }

    public Theater Theater { get; set; }

    public double Amount {  get; set; }
}
