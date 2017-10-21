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
        public override string ProfileName => "DTOMappingProfile";

        public DTOMappingProfile()
        {
                CreateMap<Article, ArticleDTO>()
                .ForMember("ArticleId", cfg => cfg.MapFrom(article => article.ArticleId))
                .ForMember("BlogTitle", cfg => cfg.MapFrom(article => article.Blog.Title))
                .ForMember("Title", cfg => cfg.MapFrom(article => article.Title))
                .ForMember("Body", cfg => cfg.MapFrom(article => article.Body))
                .ForMember("Date", cfg => cfg.MapFrom(article => article.Date))
                .ForMember("UserProfileId", cfg => cfg.MapFrom(article => article.UserProfileId))
                .ForMember("UserName", cfg => cfg.MapFrom(article => article.UserProfile.ApplicationUser.UserName))
                .ForMember("Tags", cfg => cfg.MapFrom(article => article.Tags.Select(tag => tag.Name)))
                .ForMember("Comments", cfg => cfg.MapFrom(article => article.Comments.Select(comment => $"[{article.Date.ToUniversalTime()}]" + comment.Profile.ApplicationUser.UserName +": "+comment.Body)));

            base.CreateMap<Blog, BlogDTO>()
                .ForMember("BlogId", cfg => cfg.MapFrom(blog => blog.BlogId))
                .ForMember("Title", cfg => cfg.MapFrom(blog => blog.Title))            
                .ForMember("Description", cfg => cfg.MapFrom(blog => blog.Description))
                .ForMember("ArticlesCount", cfg => cfg.MapFrom(blog => blog.Articles.Count));

            base.CreateMap<UserProfile, UserDTO>();
            base.CreateMap<Comment, CommentDTO>()
                .ForMember("UserName", cfg => cfg.MapFrom(comment => comment.Profile.Name))
                .ForMember("ArticleId", cfg => cfg.MapFrom(comment => comment.Article.ArticleId))
                .ForMember("ArticleTitle", cfg => cfg.MapFrom(comment => comment.Article.Title));
        }

        

    }
}


