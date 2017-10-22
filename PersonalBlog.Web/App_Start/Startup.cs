using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Ninject;
using Owin;
using PersonalBlog.Domain.Infrastructure;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Domain.Services;
using PersonalBlog.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace PersonalBlog.Web
{
    public class Startup
    {
        private readonly IKernel _kernel = new StandardKernel(new ServiceModule(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.CreatePerOwinContext<IUserService>(()=> _kernel.Get<IUserService>()); 

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            

        }


    }
}