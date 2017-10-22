using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Ninject;
using PersonalBlog.Domain.Infrastructure;
using PersonalBlog.Web.AutoMapper;

namespace PersonalBlog.Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory(string connectionString)
        {
            _kernel = new StandardKernel(new ServiceModule(connectionString), new AutoMapperModule());    
          
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _kernel.Get(controllerType);
        }

       
    }
}