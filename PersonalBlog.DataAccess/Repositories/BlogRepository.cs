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
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationContext _context;

        public BlogRepository(ApplicationContext context)
        {
            _context = context;
        }


        public void Create(Blog item)
        {
            _context.Blogs.Add(item);
        }

        public Blog Get(int id)
        {
            return _context.Blogs.Find(id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _context.Blogs.ToList().OrderBy(blog => blog.Title);
        }

        public IEnumerable<Blog> Find(Expression<Func<Blog, bool>> predicate)
        {
            return _context.Blogs.Where(predicate).OrderBy(blog => blog.Title).ToList();
        }

        public void Update(Blog item)
        {
            _context.Entry(item).State = EntityState.Modified;           
        }

        public void Delete(int id)
        {
            Blog blog = _context.Blogs.Find(id);
            if (blog !=null)
            {
                _context.Blogs.Add(blog);
            }
        }

        public Blog FindBy(Expression<Func<Blog, bool>> predicate)
        {
            return _context.Blogs.SingleOrDefault(predicate);
        }
    }
}
