namespace TestAPI.Models
using System.ComponentModel.DataAnnotations;

namespace projects.Models
{
    public class Projects
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


    }
}
