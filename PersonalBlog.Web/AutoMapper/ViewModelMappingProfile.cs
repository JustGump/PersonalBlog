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
      
        public ViewModelMappingProfile()
        {
            CreateMap<ArticleDTO, ArticleViewModel>()
                .ForMember(model => model.Tags, cfg => cfg.MapFrom(dto => dto.Tags))
                .ReverseMap();
            CreateMap<BlogDTO, BlogViewModel>();
          
            CreateMap<UserDTO, ProfileViewModel>()
                .ForMember(model => model.UserName, cfg => cfg.MapFrom(dto => dto.UserName))
                .ForMember(model => model.Email, cfg => cfg.MapFrom(dto => dto.Email))
                .ForMember(model => model.Role, cfg => cfg.MapFrom(dto => dto.Role));
            CreateMap<CommentViewModel, CommentDTO>();
        }
    }
}