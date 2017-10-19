using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.DataAccess.Interfaces;

namespace PersonalBlog.DataAccess.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationContext _context;

        public ArticleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Article item)
        {
            _context.Articles.Add(item);
        }

        public Article Get(int id)
        {
            return _context.Articles.Find(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles.ToList();
        }

        
        public IEnumerable<Article> Find(Expression<Func<Article, bool>> predicate)
        {
            return _context.Articles.Where(predicate).ToList();
        }

        public void Update(Article item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Article article = _context.Articles.Find(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
            }
        }
    }
}
