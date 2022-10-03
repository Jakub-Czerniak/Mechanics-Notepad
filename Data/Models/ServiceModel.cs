namespace DataLibrary.Models
{
    public class ServiceModel
    {
        public int ID { get; set; }
        public string ShortDesc { get; set; }
        public string Notes { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public int CarID { get; set; }
        public List<Image> Photos { get; set; }
    }
}