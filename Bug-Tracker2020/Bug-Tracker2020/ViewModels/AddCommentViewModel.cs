using Bug_Tracker2020.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.ViewModels
{
    public class AddCommentViewModel
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string CommentBody { get; set; }

        [Required]
        public Bug Bug { get; set; }



        public AddCommentViewModel()
        {
        }
    }
}
