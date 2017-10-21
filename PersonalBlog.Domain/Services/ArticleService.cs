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
using PersonalBlog.Domain.AutoMapper;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Interfaces;

namespace PersonalBlog.Domain.Services
{
    class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            _unitOfWork = new UnitOfWork(connectionString);
            _mapper = new MapperConfiguration(expression => expression.AddProfile(new DTOMappingProfile())).CreateMapper();
        }

        /// <summary>
        /// Creates a new article.
        /// </summary>
        /// <param name="articleDTO">  </param>
        /// <exception cref="ArgumentNullException">
        ///  if <paramref name="articleDTO"/> is <c>null</c>.
        /// </exception>
        public void Create(ArticleDTO articleDTO)
        {
            if (articleDTO == null) throw new ArgumentNullException(nameof(articleDTO));

            Blog blog = _unitOfWork.BlogRepository.FindByTitle(articleDTO.BlogTitle);
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

        /// <summary>
        /// Returns entered count of articles.
        /// </summary>
        /// <param name="count"> count of articles </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///  if <paramref name="count"/> is <c>out of range</c>.
        /// </exception>
        public IEnumerable<ArticleDTO> Take(int count)
        {
            if (count < 1) throw new ArgumentOutOfRangeException(nameof(count));
            return _mapper.Map<IEnumerable<ArticleDTO>>(_unitOfWork.ArticleRepository.GetAll());
        }
       
        /// <summary>
        /// Returns all articles.
        /// </summary>
        public IEnumerable<ArticleDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ArticleDTO>>(_unitOfWork.ArticleRepository.GetAll());
        }

        /// <summary>
        /// Returns article by Id.
        /// </summary>
        /// <param name="articleId"> article's id</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///  if <paramref name="articleId"/> is <c>out of range</c>.
        /// </exception>
        public ArticleDTO GetById(int articleId)
        {
            if (articleId < 1) throw new ArgumentOutOfRangeException(nameof(articleId));
            return _mapper.Map<ArticleDTO>(_unitOfWork.ArticleRepository.Get(articleId));
        }
        
        /// <summary>
        /// Returns articles by blog's Id.
        /// </summary>
        /// <param name="blogId"> blog's id</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///  if <paramref name="blogId"/> is <c>out of range</c>.
        /// </exception>
        public IEnumerable<ArticleDTO> GetByBlogId(int blogId)
        {
            if (blogId < 1) throw new ArgumentOutOfRangeException(nameof(blogId));
            return _mapper.Map<IEnumerable<ArticleDTO>>(_unitOfWork.ArticleRepository.Find(article => article.BlogId == blogId));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
