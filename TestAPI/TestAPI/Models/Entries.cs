namespace TestAPI.Models
{
    public class Entries
    {
        public int Id { get; set; }

        public int ProjectsId { get; set; }

        public int UsersId { get; set; }

        public string? Notes { get; set; }

        public int Timespend { get; set;}

        public DateTime Date { get; set; }
    }
}
