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
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginViewModel() { }
    }
}
