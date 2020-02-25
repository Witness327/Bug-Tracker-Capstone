using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Bug_Tracker2020.Models
{
    public class Bug
    {
        public int ID { get; set; }
        public string CreatedDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string LastModifiedDate { get; set; }
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public int AdminID { get; set; }
        public string AdminFirstName { get; set; }

        public string Status { get; set; }
        public List<Comment> Comments { get; set; }



    }
}
