using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.AutoMapper
{
    public class ViewModelMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelMappingProfile";
        public ViewModelMappingProfile()
        {
            CreateMap<ArticleDTO, ArticleViewModel>().ReverseMap();
            CreateMap<BlogDTO, BlogViewModel>();    
            
            //CreateMap<UserProfile, UserDTO>();
            //CreateMap<CommentViewModel, CommentDTO>();
        }
    }
}