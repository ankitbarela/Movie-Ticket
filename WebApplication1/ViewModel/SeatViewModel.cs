using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class SeatViewModel
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string TotalRow { get; set; }
        [ForeignKey("ScreenId")]
        public int ScreenId { get; set; }
        public int PricePerSeat { get; set; }
    }
}
