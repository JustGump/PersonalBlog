using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.DataAccess.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public virtual UserProfile Profile { get; set; }

        [Required]    
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        [Required]
        public DateTime Date { get; set; }       
    }
}
