using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PersonalBlog.Domain.AutoMapper;
using PersonalBlog.Domain.DataTransferObjects;

namespace PersonalBlog.Web.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Initialize()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {            
                cfg.AddProfile(new DTOMappingProfile());
              //  cfg.AddProfile(new ViewModelMappingProfile());
            });
            return config;
        }
    }
}