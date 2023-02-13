using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class ScreenViewModel
    {
        public int ScreenId { get; set; }
        public int ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public int PricePerSeat { get; set; }
    }
}
