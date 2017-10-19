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
    public class ProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationContext _context;

        public ProfileRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(UserProfile item)
        {
            _context.UserProfiles.Add(item);
            //  _context.SaveChanges();
        }

        public UserProfile Get(int id)
        {
            return _context.UserProfiles.Find(id);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _context.UserProfiles.ToList();
        }

        public IEnumerable<UserProfile> Find(Expression<Func<UserProfile, bool>> predicate)
        {
            return _context.UserProfiles.Where(predicate).ToList();
        }

        public void Update(UserProfile item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserProfile profile = _context.UserProfiles.Find(id);
            if (profile != null)
            {
                _context.UserProfiles.Remove(profile);
            }
        }

        public IEnumerable<UserProfile> GetPaginated(int page = 1, int rows = 20)
        {
            return _context.UserProfiles.Skip(page - 1 * rows).Take(rows);
        }
    }
}
