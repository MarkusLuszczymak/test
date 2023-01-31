using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models.Account
{
    public class ResetPasswordRequest
    {
        [Required]
        public string jwtToken { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }


    }

}
