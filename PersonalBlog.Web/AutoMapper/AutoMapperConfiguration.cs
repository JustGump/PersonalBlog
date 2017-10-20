using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using PersonalBlog.Domain.AutoMapper;
using PersonalBlog.Domain.DataTransferObjects;

namespace PersonalBlog.Web.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfigurationExpression Initialize()
        {
            var config = new MapperConfigurationExpression();
            config.AddProfile(new DTOMappingProfile());
            return config;
        }
    }
}