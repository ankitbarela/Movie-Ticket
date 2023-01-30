namespace WebApplication1.Model
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int StateCode { get; set; }
        public bool IsActive { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
    }
}
