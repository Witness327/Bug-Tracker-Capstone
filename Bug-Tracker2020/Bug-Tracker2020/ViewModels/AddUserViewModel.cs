using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.ViewModels
{
    public class AddUserViewModel
    { 
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool Admin { get; set; }

        public AddUserViewModel() { }
    }
}
