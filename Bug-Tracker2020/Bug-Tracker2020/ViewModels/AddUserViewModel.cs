using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.ViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "You must enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter an email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must re-enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Verify Password")]
        [Compare("Password", ErrorMessage = "Both passwords must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool Admin { get; set; }

        public AddUserViewModel() { }
    }
}
