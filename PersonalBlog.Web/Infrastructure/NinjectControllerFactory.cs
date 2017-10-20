using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using PersonalBlog.Domain.Infrastructure;

namespace PersonalBlog.Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(string connectionString)
        {
            _kernel = new StandardKernel(new ServiceModule(connectionString));
           
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _kernel.Get(controllerType);
        }
    }
}