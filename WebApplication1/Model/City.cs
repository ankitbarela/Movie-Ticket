using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        [ForeignKey("StateId")]
        public int StateId { get; set; }
        public virtual State StateModel { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
