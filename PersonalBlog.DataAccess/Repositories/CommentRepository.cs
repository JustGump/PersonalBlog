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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _context;

        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Comment item)
        {
            _context.Comments.Add(item);
        }

        public Comment Get(int id)
        {
            return _context.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate)
        {
            return _context.Comments.Where(predicate).ToList();
        }

        public void Update(Comment item)
        {
           _context.Entry(item).State = EntityState.Modified;         
        }

        public void Delete(int id)
        {
            Comment comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }
        }
    }
}
