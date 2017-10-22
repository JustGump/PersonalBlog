using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.DataAccess.Interfaces;
using PersonalBlog.DataAccess.UnitOfWork;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Interfaces;

namespace PersonalBlog.Domain.Services
{
    class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            _unitOfWork = new UnitOfWork(connectionString);
        }

        /// <summary>
        /// Creates a new comment.
        /// </summary>
        /// <param name="commentDTO">  </param>
        /// <exception cref="ArgumentNullException">
        ///  if <paramref name="commentDTO"/> is <c>null</c>.
        /// </exception>
        public void Create(CommentDTO commentDTO)
        {
            if (commentDTO == null) throw new ArgumentNullException(nameof(commentDTO));
            Comment newComment = new Comment()
            {
                Date = DateTime.Now,
                Profile = _unitOfWork.UserProfileRepository.Find(profile => profile.Id == commentDTO.UserId).SingleOrDefault(),
                Article = _unitOfWork.ArticleRepository.Get(commentDTO.ArticleId),
                Body = commentDTO.Body
            };
            _unitOfWork.CommentRepository.Create(newComment);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
