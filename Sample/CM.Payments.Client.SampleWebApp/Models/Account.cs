using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CM.Payments.Client.SampleWebApp.Models
{
    public class Account
    {
        [Required]
        public string FirstName { get; set; }

        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
    }
}