using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PersonalBlog.Domain.AutoMapper;
using PersonalBlog.Web.AutoMapper;
using PersonalBlog.Web.Infrastructure;

namespace PersonalBlog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            Mapper.Initialize(AutoMapperConfiguration.Initialize());

        }
    }
}
