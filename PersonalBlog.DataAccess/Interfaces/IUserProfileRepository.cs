using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.DataAccess.Entities;

namespace PersonalBlog.DataAccess.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        IEnumerable<UserProfile> GetPaginated(int page = 1, int rows = 20);
    } 

}
