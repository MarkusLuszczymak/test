using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models;
    public class Projects
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


    }

