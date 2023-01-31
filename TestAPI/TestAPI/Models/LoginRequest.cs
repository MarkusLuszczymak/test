using Microsoft.IdentityModel.JsonWebTokens;
using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class LoginRequest
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
    }
}


