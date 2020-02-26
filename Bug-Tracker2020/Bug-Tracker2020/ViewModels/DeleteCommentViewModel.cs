using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.ViewModels
{
    public class DeleteCommentViewModel
    {

        public int ID { get; set; }

        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public int AdminID { get; set; }

        public string AdminFirstName { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string CommentBody { get; set; }

        [Required]
        public int BugID { get; set; }

        public DeleteCommentViewModel()
        {
        }
    }
}
