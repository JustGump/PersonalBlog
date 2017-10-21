using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.DataTransferObjects
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }
        public string BlogTitle { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string UserProfileId { get; set; }
        public string UserName { get; set; }
        public List<string> Comments { get; set; }
        public List<string> Tags { get; set; }
    }
}
