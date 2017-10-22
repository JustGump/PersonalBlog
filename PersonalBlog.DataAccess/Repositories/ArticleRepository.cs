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
            var result = _context.Articles
                .Include(article => article.UserProfile.ApplicationUser)
                .Include(article => article.Comments)
                .FirstOrDefault(article => article.ArticleId == id);

            return result;
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles
                .Include(article => article.UserProfile.ApplicationUser)
                .Include(article => article.Comments)
                .OrderByDescending(article => article.Date)
                .ToList();
        }

        
        public IEnumerable<Article> Find(Expression<Func<Article, bool>> predicate)
        {
            return _context.Articles
                .Include(article => article.Blog)
                .Include(article => article.UserProfile.ApplicationUser)
                .Include(article => article.Comments)
                .Include(article => article.Tags)
                .Where(predicate)
                .OrderByDescending(article => article.Date)
                .ToList();
        }

        public Article FindBy(Expression<Func<Article, bool>> predicate)
        {
          return  _context.Articles.SingleOrDefault(predicate);
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
