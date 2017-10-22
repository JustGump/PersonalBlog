using System;
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
    public class BlogService : IBlogService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
     
        public BlogService(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

            _unitOfWork = new UnitOfWork(connectionString);
            _mapper = new MapperConfiguration(expression => expression.AddProfile(new DTOMappingProfile())).CreateMapper();
        }

        /// <summary>
        /// Creates a new blog.
        /// </summary>
        /// <param name="blogDTO">  </param>
        /// <exception cref="ArgumentNullException">
        ///  if <paramref name="blogDTO"/> is <c>null</c>.
        /// </exception>
        public void Create(BlogDTO blogDTO)
        {
            if (blogDTO == null) throw new ArgumentNullException(nameof(blogDTO));

            _unitOfWork.BlogRepository.Create(new Blog()
            {
                Title = blogDTO.Title,
                Description = blogDTO.Description,               
            });
            _unitOfWork.Save();
        }
       
        /// <summary>
        /// Returns all articles.
        /// </summary>
        public IEnumerable<BlogDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogDTO>>(_unitOfWork.BlogRepository.GetAll());          
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
