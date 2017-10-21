using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBlog.Domain.DataTransferObjects;

namespace PersonalBlog.Web.Models
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArticlesCount { get; set; }  
    }
}