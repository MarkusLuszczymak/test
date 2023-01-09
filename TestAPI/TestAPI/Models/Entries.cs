namespace TestAPI.Models
{
    public class Entries
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public DateTime DateTime { get; set; }

        public string Notes { get; set; }
    }
}
