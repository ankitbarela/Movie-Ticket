using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class ShowViewModel
    {
        public int ShowId { get; set; }
        public string Duretion { get; set; }
        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
    }
}
