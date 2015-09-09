using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDebateWeb.Models
{
    public class DebateTopics
    {
        [Key]
        public int id { get; set; }

        public int CategoryID { get; set; }
        
        public int UserID { get; set; }
       
        [Required]
        [StringLength(1024)]
        public string Topic { get; set; }
        
        public int LikesCount { get; set; }

        public DateTime AddedOn { get; set; }
    }
}