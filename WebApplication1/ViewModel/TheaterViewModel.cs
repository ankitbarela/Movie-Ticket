using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class TheaterViewModel
    {
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string Rating { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
    }
}
