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
        IEnumerable<ArticleDTO> Take(int count);
        IEnumerable<ArticleDTO> GetAll();
        ArticleDTO GetById(int articleId);
        IEnumerable<ArticleDTO> GetByBlogId(int blogId);
        IEnumerable<ArticleDTO> GetByTagName(string tagname);
        IEnumerable<ArticleDTO> GetByUserId(string id);
    }
}
