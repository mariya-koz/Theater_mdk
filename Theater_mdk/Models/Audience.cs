namespace Theater_mdk.Models
{
    public class Audience : EFModel
    {
        public string LastName { get; set; }
        public string? Passport { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
