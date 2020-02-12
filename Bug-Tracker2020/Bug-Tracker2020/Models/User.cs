using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.Models
{
    public class User
    {
        public string EmailAddress { get; set; }
        
        public string Password { get; set; }
        
        public bool Admin { get; set; }
        
        public int UserID { get; set; }

        public IList<Bug> Bugs { get; set; }

    }
}
