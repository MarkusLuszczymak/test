namespace TestAPI.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }

}
