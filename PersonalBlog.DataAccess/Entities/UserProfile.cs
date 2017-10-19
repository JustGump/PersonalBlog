using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.DataAccess.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ApplicationUser ApplicationUser{ get; set; }

        public virtual List<Article> Articles { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
