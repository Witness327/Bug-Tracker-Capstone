using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bug_Tracker2020.Models;
using Bug_Tracker2020.ViewModels;
using Microsoft.AspNetCore.Http;
namespace Bug_Tracker2020.ViewModels
{
    public class EditBugViewModel
    {
        public int ID { get; set; }
        public string CreatedDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string LastModifiedDate { get; set; }
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        [Required]
        [Display(Name = "Admin")]
        public int AdminID { get; set; }
        public string AdminFirstName { get; set; }
        public List<SelectListItem> Admins { get; set; }
        public string Status { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public EditBugViewModel()
        {
        }

    }
}