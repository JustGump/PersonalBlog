using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Domain.DataTransferObjects;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IArticleService : IDisposable
    {
        void Create(ArticleDTO articleDTO);
        IEnumerable<ArticleDTO> GetAll(int count);
        IEnumerable<ArticleDTO> GetAll();
        IEnumerable<ArticleDTO> GetByBlog(string BlogTitle);
    }
}
