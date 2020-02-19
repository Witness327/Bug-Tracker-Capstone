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
    public class AddBugViewModel
    {
        [Required]
        public int UserID { get; set; }
        
        public string CreatedDate { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [Display(Description = "Description")]
        public string Description { get; set; }

        public List<SelectListItem> AdminCategories { get; set; }


        public AddBugViewModel()
        {
        }

        public AddBugViewModel(IEnumerable<Admin> categories)
        {

            AdminCategories = new List<SelectListItem>();
            foreach (Admin category in categories)
            {
                AdminCategories.Add(new SelectListItem
                {
                    Text = category.FirstName,
                    Value = category.AdminID.ToString(),
                });
            }
        }
    }
}
