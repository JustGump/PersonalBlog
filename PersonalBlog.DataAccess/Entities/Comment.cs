using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.DataAccess.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Body { get; set; }

        public UserProfile ProfileId { get; set; }
        public UserProfile Profile { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime Date { get; set; }       
    }
}
