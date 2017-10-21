using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.DataTransferObjects
{
   public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Body { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }

        public DateTime Date { get; set; }
    }
}
