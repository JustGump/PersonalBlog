using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.DataAccess.Identity;
using PersonalBlog.DataAccess.Interfaces;
using PersonalBlog.DataAccess.Repositories;

namespace PersonalBlog.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(string connectionString)
        {
            _context = new ApplicationContext(connectionString);

            ArticleRepository = new ArticleRepository(_context);
            BlogRepository = new BlogRepository(_context);
            CommentRepository = new CommentRepository(_context);
            UserProfileRepository = new ProfileRepository(_context);
            TagRepository = new TagRepository(_context);
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
        }

        public IArticleRepository ArticleRepository { get; }
        public IBlogRepository BlogRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IUserProfileRepository UserProfileRepository { get; }
        public ITagRepository TagRepository { get; }

        public ApplicationRoleManager RoleManager { get; }
        public ApplicationUserManager UserManager { get; }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
