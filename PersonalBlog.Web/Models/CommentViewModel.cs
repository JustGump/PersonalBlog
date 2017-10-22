using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlog.Web.Models
{
    public class CommentViewModel
    {
        [Required]
        public string Body { get; set; }
      
    }
}