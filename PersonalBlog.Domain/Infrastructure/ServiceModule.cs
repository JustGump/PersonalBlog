using System;
using System.Reflection;
using Ninject;
using Ninject.Modules;
using PersonalBlog.DataAccess.Infrastructure;
using PersonalBlog.DataAccess.Interfaces;
using PersonalBlog.DataAccess.UnitOfWork;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Domain.Services;

namespace PersonalBlog.Domain.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connectionString) 
        {
            _connectionString = connectionString;

        }

        public override void Load()
        {
            Bind<IUserService>().To<UserService>().WithConstructorArgument(_connectionString);
            Bind<IBlogService>().To<BlogService>().WithConstructorArgument(_connectionString);
            Bind<IArticleService>().To<ArticleService>().WithConstructorArgument(_connectionString);
        }

    }
}