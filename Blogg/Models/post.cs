using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class post
    {
        public int postID { get; set; }
        [MaxLength(50, ErrorMessage ="Max lengt 50 charakters")]
        [Required(ErrorMessage = "Måste ha en titel")]
        public string postTitle { get; set; }
        [MaxLength(2000)]
        public string postBody { get; set; }
        public string categoryName { get; set; }
        public DateTime postDate { get; set; }
    }
}