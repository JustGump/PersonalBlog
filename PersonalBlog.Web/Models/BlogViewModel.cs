using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBlog.Domain.DataTransferObjects;

namespace PersonalBlog.Web.Models
{
    public class BlogViewModel
    {
        public IEnumerable<BlogDTO> Blogs { get; set; }
    }
}