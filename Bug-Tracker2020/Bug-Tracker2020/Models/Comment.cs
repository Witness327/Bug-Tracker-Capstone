using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CommentBody { get; set; }
        public string Date { get; set; }
        public Bug Bug { get; set; }
    }
}
