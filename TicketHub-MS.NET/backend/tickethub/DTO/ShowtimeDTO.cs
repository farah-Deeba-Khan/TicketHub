using System.ComponentModel.DataAnnotations.Schema;

namespace tickethub.DTO
{
    public class ShowtimeDTO
    {
        public long Id { get;set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int AvailableSeats { get; set; }
        public double Amount { get; set; }
        public MovieDTO Movie { get; set; }
        public TheaterDTO Theater { get; set; }
    }
}
