using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string TotalRow { get; set; }
        [ForeignKey("ScreenId")]
        public int ScreenId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int PricePerSeat { get; set; }

    }
}
