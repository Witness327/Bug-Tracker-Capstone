using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.Models
{
    
    public class Admin 
    {
        public int AdminID { get; set; }

        public string FirstName { get; set; }
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool AdminRole { get; set; }

        public IList<Bug> Bugs { get; set; }
    }
}
