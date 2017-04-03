using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CM.Payments.Client.SampleWebApp.Models
{
    public class OrderModel
    {
        [Display(Name = "Address")]
        [Required(ErrorMessage = "An address is required.")]
        [RegularExpression(@"^(\w[\s\w]+?)\s*(\d+\s*)$", ErrorMessage = "Not a valid address. Format should look like: [street name] [number]")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "A city is required.")]
        public string City { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "A date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "An email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "A first name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "A last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "A phone number is required.")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Postal")]
        [Required(ErrorMessage = "A postal code is required.")]
        [RegularExpression(@"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", ErrorMessage = "Not a valid postal code.")]
        public string PostalCode { get; set; }

        public string[] GetFormattedAddress()
        {
            return this.Address.Split(' ');
        }

        public string GetInitials()
        {
            return this.FirstName.Split(' ').Aggregate("", (xs, x) => xs + x.First());
        }
    }
}