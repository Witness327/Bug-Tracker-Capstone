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
    public class UpdateBugViewModel
    {
        [Required]
        public int UserID { get; set; }

        public int ID { get; set; }

        public string CreatedDate { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [Display(Description = "Description")]
        public string Description { get; set; }

        public string UserFirstName { get; set; }
        public string LastModifiedDate { get; set; }
        public string AdminID { get; set; }
        public string AdminFirstName { get; set; }
        public string Status { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public List<SelectListItem> ListOfAdminFirstNames { get; set; }

       


        public UpdateBugViewModel()
        {
        }

        //public UpdateBugViewModel(IEnumerable<ListofAdminFirstName> firstnames)
        //{

        //    ListOfAdminFirstNames = new List<SelectListItem>();
        //    foreach(ListofAdminFirstName category in firstnames)
        //    {
        //        ListOfAdminFirstNames.Add(new SelectListItem
        //        {
        //            Text = category.Name,
        //            Value = category.ID.ToString(),
        //        });
        //    }
        //}
    }
}
