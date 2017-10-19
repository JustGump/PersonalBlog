using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.DataAccess.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

        public virtual List<Article> Articles { get; set; }
    }
}
