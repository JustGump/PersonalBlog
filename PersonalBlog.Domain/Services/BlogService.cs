using System;
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
    public class BlogService : IBlogService
        
    {
        private readonly IUnitOfWork _unitOfWork;

     
          public BlogService(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

            _unitOfWork = new UnitOfWork(connectionString);
        }
        public void Create(string title, string discription, string userid)
        {
            _unitOfWork.BlogRepository.Create(new Blog()
            {
                Title = title,
                Description = discription,               
            });
            _unitOfWork.Save();
        }


        public IEnumerable<BlogDTO> GetAll()
        {
            //Mapper.Initialize(m => m.CreateMap<Blog, BlogDTO>());
                
               
            return Mapper.Map<IEnumerable<Blog>, List<BlogDTO>>(_unitOfWork.BlogRepository.GetAll());
            /*   Mapper.Initialize(m => m.CreateMap<Blog, BlogDTO>()
                   .ForMember("Title", e => e.MapFrom(blog => blog.Title))
                   .ForMember("Description", cfg => cfg.MapFrom(blog => blog.Description)).
                   ForMember("UserName", cfg => cfg.MapFrom(blog => blog.UserProfile.ApplicationUser.UserName))
                   .ForMember("Date", cfg => cfg.MapFrom(blog => blog.Date)));
               return Mapper.Map<IEnumerable<Blog>, List<BlogDTO>>(_unitOfWork.BlogRepository.Find());*/
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
