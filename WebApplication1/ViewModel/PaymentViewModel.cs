using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class PaymentViewModel
    {
        [Key]
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string Expiry { get; set; }
        public int Cvv { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }
    }   
}
