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
    
        public virtual UserProfile Profile { get; set; }
        public virtual Article Article { get; set; }
        public DateTime Date { get; set; }       
    }
}
