using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.DataAccess.Interfaces;
using PersonalBlog.DataAccess.UnitOfWork;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Interfaces;

namespace PersonalBlog.Domain.Services
{
    class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(string connectionString)
        {
            _unitOfWork = new UnitOfWork(connectionString);
        }

        public void Create(ArticleDTO articleDTO)
        {
            var blog = _unitOfWork.BlogRepository.FindByTitle(articleDTO.BlogTitle);
            if (blog == null)
            {
                blog = new Blog(){Title = articleDTO.BlogTitle, Description = ""};
            }
            
            Article article = new Article()
            {
                Blog = blog,
                Title =  articleDTO.Title,
                Body = articleDTO.Body,
                UserProfileId = articleDTO.UserProfileId,
                Date = DateTime.Now
                
            };
            _unitOfWork.ArticleRepository.Create(article);
            _unitOfWork.Save();
        }
        public IEnumerable<ArticleDTO> GetAll(int count)
        {
            Mapper.Initialize(m => m.CreateMap<Article, ArticleDTO>()
                .ForMember("UserName", e => e.MapFrom(article => article.UserProfile.ApplicationUser.UserName))
                .ForMember("Tags", cfg => cfg.MapFrom(article => article.Tags.Select(tag => tag.Name))));
            return Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(_unitOfWork.ArticleRepository.GetAll());
        }
        public IEnumerable<ArticleDTO> GetAll()
        {    
               Mapper.Initialize(m => m.CreateMap<Article, ArticleDTO>()
                   .ForMember("UserName", e => e.MapFrom(article => article.UserProfile.ApplicationUser.UserName))
                   .ForMember("Tags", cfg => cfg.MapFrom(article => article.Tags.Select(tag => tag.Name))));
            return Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(_unitOfWork.ArticleRepository.GetAll());
        }

        public IEnumerable<ArticleDTO> GetByBlog(string blogTitle)
        {
            Mapper.Initialize(m => m.CreateMap<Article, ArticleDTO>()
                .ForMember("UserName", e => e.MapFrom(article => article.UserProfile.ApplicationUser.UserName))
                .ForMember("Tags", cfg => cfg.MapFrom(article => article.Tags.Select(tag => tag.Name))));
            return Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(_unitOfWork.ArticleRepository.Find(article => article.Blog.Title == blogTitle));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
