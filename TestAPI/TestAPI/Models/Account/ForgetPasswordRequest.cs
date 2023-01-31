using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
