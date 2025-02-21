//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//[Table("Bookings")]
//public class Booking : BaseEntity
//{
//    public DateTime BookingDate { get; set; }

//    public int SeatNo { get; set; }

//    [MaxLength(25)]
//    public string PaymentStatus { get; set; }

//    [ForeignKey("Showtime")]
//    public int ShowtimeId { get; set; }
//    public Showtime Showtime { get; set; }

//    [ForeignKey("User")]
//    public int UserId { get; set; }
//    public User User { get; set; }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Bookings")]
public class Booking : BaseEntity
{
    [Column("booking_date")]
    public DateTime BookingDate { get; set; } = DateTime.UtcNow; // Equivalent to @CreationTimestamp

    [Column("no_of_seat")]
    public int NoOfSeat { get; set; }

    [Column("payment_status")]
    [MaxLength(25)]
    public string PaymentStatus { get; set; }

    // ONE booking belongs to ONE showtime
    [ForeignKey("Showtime")]
    [Column("showtime_id")]
    //public int ShowtimeId { get; set; }
    public long ShowtimeId { get; set; }
    public virtual Showtime Showtime { get; set; }

    // ONE booking belongs to ONE user
    [ForeignKey("User")]
    [Column("user_id")]
    //public int UserId { get; set; }
    public long UserId { get; set; }

    public virtual User User { get; set; }

    // ONE booking can have MANY booked seats
    public virtual ICollection<BookedSeat> BookedSeats { get; set; } = new List<BookedSeat>();

    public Booking() { }

    public Booking(int noOfSeat, string paymentStatus, int showtimeId, int userId)
    {
        BookingDate = DateTime.UtcNow;
        NoOfSeat = noOfSeat;
        PaymentStatus = paymentStatus;
        ShowtimeId = showtimeId;
        UserId = userId;
        BookedSeats = new List<BookedSeat>();
    }

    public override string ToString()
    {
        return $"{base.ToString()}, BookingDate: {BookingDate}, NoOfSeat: {NoOfSeat}, PaymentStatus: {PaymentStatus}, ShowtimeId: {ShowtimeId}, UserId: {UserId}";
    }
}
