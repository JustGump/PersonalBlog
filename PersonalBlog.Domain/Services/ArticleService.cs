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
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            _unitOfWork = new UnitOfWork(connectionString);
        }
        public void Create(ArticleDTO articleDTO)
        {
            if (articleDTO == null) throw new ArgumentNullException(nameof(articleDTO));
            
            var blog = _unitOfWork.BlogRepository.FindByTitle(articleDTO.BlogTitle);
            if (blog == null)
            {
                blog = new Blog() { Title = articleDTO.BlogTitle, Description = "" };
            }

            Article article = new Article()
            {
                Blog = blog,
                Title = articleDTO.Title,
                Body = articleDTO.Body,
                UserProfileId = articleDTO.UserProfileId,
                Date = DateTime.Now

            };
            _unitOfWork.ArticleRepository.Create(article);
            _unitOfWork.Save();
        }
        public IEnumerable<ArticleDTO> GetAll(int count)
        {
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(_unitOfWork.ArticleRepository.GetAll());
        }
        public IEnumerable<ArticleDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(_unitOfWork.ArticleRepository.GetAll());
        }

        public IEnumerable<ArticleDTO> GetByBlog(string blogTitle)
        {
            if (blogTitle == null) throw new ArgumentNullException(nameof(blogTitle));          
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(_unitOfWork.ArticleRepository.Find(article => article.Blog.Title == blogTitle));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
