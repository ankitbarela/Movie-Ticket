using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Show
    {
        public int ShowId { get; set; }
        public string Duretion { get; set; }
        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
