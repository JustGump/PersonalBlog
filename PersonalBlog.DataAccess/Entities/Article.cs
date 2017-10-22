using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.DataAccess.Entities
{
   public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
