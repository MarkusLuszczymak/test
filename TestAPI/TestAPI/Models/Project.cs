using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models;
    public class Project
    {
        public int Id { get; set; }
  
        public string Name { get; set; }

        public int Kostenstelle { get; set; }
    }

