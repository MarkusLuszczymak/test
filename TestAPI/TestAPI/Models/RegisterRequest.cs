namespace TestAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
         public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

              

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }

}
