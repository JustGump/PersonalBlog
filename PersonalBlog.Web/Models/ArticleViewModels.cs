using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;


namespace PersonalBlog.Web.Models
{
    public class ArticleViewModel
    {
        [ScaffoldColumn(false)]
        public int ArticleId { get; set; }

        [Required]
        [Display(Name = "Blog")]
        public string BlogTitle { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Text")]
        public string Body { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public string UserProfileId { get; set; }

        [ScaffoldColumn(false)]
        public string UserName { get; set; }

        [ScaffoldColumn(false)]
        public List<string> Comments { get; set; }

        public List<String> Tags { get; set; }
    }
}