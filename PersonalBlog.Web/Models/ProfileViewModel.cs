using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBlog.Web.Models
{
    public class ProfileViewModel
    {
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public IEnumerable<ArticleViewModel>  ArticleViewModel { get; set; }
        public IEnumerable<CommentViewModel> CommentViewModel { get; set; }

    }
}