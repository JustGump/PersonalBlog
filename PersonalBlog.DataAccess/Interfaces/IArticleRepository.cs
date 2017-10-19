using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.DataAccess.Entities;

namespace PersonalBlog.DataAccess.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}
