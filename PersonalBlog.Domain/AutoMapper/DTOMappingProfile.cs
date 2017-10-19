using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.Domain.DataTransferObjects;

namespace PersonalBlog.Domain.AutoMapper
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            /*  base.CreateMap<Article, ArticleDTO>()
                  .ForMember("UserName", cfg => cfg.MapFrom(article => article.UserProfile.ApplicationUser.UserName))
                  .ForMember("Tags", cfg => cfg.MapFrom(article => article.Tags.Select(tag => tag.Name)));*/
            base.CreateMap<Article, ArticleDTO>();
            base.CreateMap<ArticleDTO, Article>();
        }

        
    }
}
