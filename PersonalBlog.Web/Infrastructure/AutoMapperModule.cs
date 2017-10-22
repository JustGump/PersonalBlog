using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Ninject.Modules;
using PersonalBlog.Web.AutoMapper;

namespace PersonalBlog.Web.Infrastructure
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(context => AutoMapperConfiguration.Initialize().CreateMapper());
        }
    }
}