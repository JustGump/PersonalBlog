using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.DataAccess.Identity;

namespace PersonalBlog.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        IBlogRepository BlogRepository { get; }
        ICommentRepository CommentRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        ITagRepository TagRepository { get; }
        
        ApplicationRoleManager RoleManager { get; }
        ApplicationUserManager UserManager { get; }

        Task SaveAsync();
        void Save();
    }
}
