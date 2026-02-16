namespace Theater_mdk.Models
{
    public class Ticket : EFModel
    {
        public string Title { get; set; }
        public int TimeMin { get; set; }
        public DateTime DataShow { get; set; }
        public double Price { get; set; }
    }
}
