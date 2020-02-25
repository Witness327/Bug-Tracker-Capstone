using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker2020.Models;
using System.ComponentModel.DataAnnotations;

namespace Bug_Tracker2020.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must enter an email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "You must enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginViewModel() { }
    }
}
