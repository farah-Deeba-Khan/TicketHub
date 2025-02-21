//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//public class Payment : BaseEntity
//{
//    public double Amount { get; set; }

//    public DateOnly PaymentDate { get; set; }

//    [MaxLength(25)]
//    public string PaymentMethod { get; set; }

//    [MaxLength(25)]
//    public string PaymentStatus { get; set; }

//    [ForeignKey("Booking")]
//    public int BookingId { get; set; }
//    public Booking Booking { get; set; }
//}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

public class Payment : BaseEntity
{
    [Column("amount")]
    [Required]
    public double Amount { get; set; }

    [Column("payment_date")]
    [Required]
    public DateTime PaymentDate { get; set; } // LocalDate in Java maps to DateTime in .NET

    [Column("payment_method")]
    [MaxLength(25)]
    public string PaymentMethod { get; set; }

    [Column("payment_status")]
    [MaxLength(25)]
    public string PaymentStatus { get; set; }

    [MaxLength(50)]
    [Column("transaction_id")]  
    public String TransactionId { get; set; } // Razorpay Payment ID

    [MaxLength(50)]
    [Column("order_id")]
    public String OrderId { get; set; } // Razorpay Order ID

    [ForeignKey("Booking")]
    [Column("bookingId")]
    //public int BookingId { get; set; } // Foreign key property
    public long BookingId { get; set; }

    public virtual Booking Booking { get; set; } // Navigation property

    public Payment() { }

    public Payment(double amount, DateTime paymentDate, string paymentMethod, string paymentStatus, int bookingId)
    {
        Amount = amount;
        PaymentDate = paymentDate;
        PaymentMethod = paymentMethod;
        PaymentStatus = paymentStatus;
        BookingId = bookingId;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Amount: {Amount}, PaymentDate: {PaymentDate}, PaymentMethod: {PaymentMethod}, PaymentStatus: {PaymentStatus}";
    }
}
