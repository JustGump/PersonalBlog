using Ninject.Modules;
using PersonalBlog.DataAccess.Interfaces;

namespace PersonalBlog.DataAccess.Infrastructure
{
    public class UnitOfWorkModule : NinjectModule
    {
        private readonly string _connectionString;
        public UnitOfWorkModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork.UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
