using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Model
{
    public class Payment
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
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
