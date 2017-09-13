using System.ComponentModel.DataAnnotations;

namespace CM.Payments.Client.SampleWebApp.Models
{
    public class LoginModel
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
    }
}