using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class BookedSeatsViewModel
    {
        public int BokeedSeatId { get; set; }
        public int BokeedSeatNumber { get; set; }
        [ForeignKey("ShowId")]
        public int ShowId { get; set; }
    }
}
