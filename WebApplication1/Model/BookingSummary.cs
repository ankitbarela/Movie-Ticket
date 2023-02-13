using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class BookingSummary
    {
        [Key]
        public int BookingId { get; set; }
        public string TheaterName { get; set; }
        public string MovieName { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
