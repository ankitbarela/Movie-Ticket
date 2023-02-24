using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class BookedSeats
    {
        [Key]
        public int BokeedSeatId { get; set; }
        public int BokeedSeatNumber { get;set; }
        [ForeignKey("ShowId")]
        public int ShowId { get; set; }
    }
}
