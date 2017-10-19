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
            return _context.Blogs.ToList();
        }

        public IEnumerable<Blog> Find(Expression<Func<Blog, bool>> predicate)
        {
            return _context.Blogs.Where(predicate).ToList();
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

        public Blog FindByTitle(string title)
        {
            return _context.Blogs.FirstOrDefault(blog => blog.Title == title);
        }
    }
}
