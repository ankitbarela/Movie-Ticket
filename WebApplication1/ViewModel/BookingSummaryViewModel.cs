using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class BookingSummaryViewModel
    {
        public int BookingId { get; set; }
        public string TheaterName { get; set; }
        public string MovieName { get; set; }
        public int NumberOfSeats { get; set; }
        public string SeatNumbers { get; set; }
        public List<int> BookedSeats { get; set;}
        [ForeignKey("ShowId")]
        public int ShowId { get; set; }
    }
}
