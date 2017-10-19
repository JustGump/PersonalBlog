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
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationContext _context;

        public TagRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Tag item)
        {
            _context.Tags.Add(item);
        }

        public Tag Get(int id)
        {
            return _context.Tags.Find(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public IEnumerable<Tag> Find(Expression<Func<Tag, bool>> predicate)
        {
            return _context.Tags.Where(predicate).ToList();
        }

        public void Update(Tag item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Tag tag = _context.Tags.Find(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
            }
        }
    }
}
