using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BookedSeat : BaseEntity
{
    [Column("seat_no")]
    [Required]
    public string SeatNo { get; set; }

    // Many booked seats belong to ONE booking
    [ForeignKey("Booking")]
    [Column("booking_id")]
    //public int BookingId { get; set; }
    public long BookingId { get; set; }

    public virtual Booking Booking { get; set; }

    // Many booked seats belong to ONE showtime
    [ForeignKey("Showtime")]
    [Column("showtime_id")]
    //public int ShowtimeId { get; set; }
    public long ShowtimeId { get; set; }

    public virtual Showtime Showtime { get; set; }

    public BookedSeat() { }

    public BookedSeat(string seatNo, int bookingId, int showtimeId)
    {
        SeatNo = seatNo;
        BookingId = bookingId;
        ShowtimeId = showtimeId;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, SeatNo: {SeatNo}, BookingId: {BookingId}, ShowtimeId: {ShowtimeId}";
    }
}
