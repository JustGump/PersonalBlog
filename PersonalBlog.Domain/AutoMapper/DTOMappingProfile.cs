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
                CreateMap<Article, ArticleDTO>()
                .ForMember(dto => dto.BlogTitle, cfg => cfg.MapFrom(article => article.Blog.Title))
                .ForMember(dto => dto.UserName, cfg => cfg.MapFrom(article => article.UserProfile.ApplicationUser.UserName))
                .ForMember(dto => dto.Tags, cfg => cfg.MapFrom(article => article.Tags.Select(tag => tag.Name)))
                .ForMember(dto => dto.Comments, cfg => cfg.MapFrom(article => article.Comments.Select(comment => $"[{article.Date.ToUniversalTime()}]" + comment.Profile.ApplicationUser.UserName +": "+comment.Body)));

            base.CreateMap<Blog, BlogDTO>()
                .ForMember(dto => dto.ArticlesCount, cfg => cfg.MapFrom(blog => blog.Articles.Count));

            base.CreateMap<UserProfile, UserDTO>()
                .ForMember(dto => dto.Id, cfg => cfg.MapFrom(profile => profile.Id))
                .ForMember(dto => dto.UserName, cfg => cfg.MapFrom(profile => profile.ApplicationUser.UserName))
                .ForMember(dto => dto.Description, cfg => cfg.MapFrom(profile => profile.Description))
                .ForMember(dto => dto.Email, cfg => cfg.MapFrom(profile => profile.ApplicationUser.Email));

            base.CreateMap<Comment, CommentDTO>()
                .ForMember(dto => dto.UserName, cfg => cfg.MapFrom(comment => comment.Profile.Name))
                .ForMember(dto => dto.ArticleId, cfg => cfg.MapFrom(comment => comment.Article.ArticleId))
                .ForMember(dto => dto.ArticleTitle, cfg => cfg.MapFrom(comment => comment.Article.Title));
        }

        

    }
}


