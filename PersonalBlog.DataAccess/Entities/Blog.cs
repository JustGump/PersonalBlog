using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.DataAccess.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public virtual List<Article> Articles { get; set; }
        /*
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        */
    }
}
