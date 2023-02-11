using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Theater
    {
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string Rating { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
