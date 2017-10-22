using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.DataAccess.Interfaces;
using PersonalBlog.DataAccess.UnitOfWork;
using PersonalBlog.Domain.AutoMapper;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Infrastructure;
using PersonalBlog.Domain.Interfaces;

namespace PersonalBlog.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            _unitOfWork = new UnitOfWork(connectionString);
            _mapper = new MapperConfiguration(expression => expression.AddProfile(new DTOMappingProfile())).CreateMapper();
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userDto">  </param>
        /// <exception cref="ArgumentNullException">
        ///  if <paramref name="userDto"/> is <c>null</c>.
        /// </exception>
        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            ApplicationUser user = await _unitOfWork.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await _unitOfWork.UserManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Any())
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                await _unitOfWork.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                UserProfile profile = new UserProfile() { Id = user.Id, Description = "profileeeee" };
                _unitOfWork.UserProfileRepository.Create(profile);
                await _unitOfWork.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userDto">  </param>
        /// <exception cref="ArgumentNullException">
        ///  if <paramref name="userDto"/> is <c>null</c>.
        /// </exception>
        public OperationDetails Create(UserDTO userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            ApplicationUser user = _unitOfWork.UserManager.FindByEmail(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = _unitOfWork.UserManager.Create(user, userDto.Password);

                if (result.Errors.Any())
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                _unitOfWork.UserManager.AddToRole(user.Id, userDto.Role);

                UserProfile profile = new UserProfile() { Id = user.Id, Description = "profileeeee" };
                _unitOfWork.UserProfileRepository.Create(profile);
                _unitOfWork.Save();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        /// <summary>
        /// User Authentication.
        /// </summary>
        /// <param name="userDto">  </param>
        /// <exception cref="ArgumentNullException">
        ///  if <paramref name="userDto"/> is <c>null</c>.
        /// </exception>
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await _unitOfWork.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await _unitOfWork.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
        /// <summary>
        /// Return user by id.
        /// </summary>
        /// <param name="id">  </param>
        /// <exception cref="ArgumentNullException">
        ///  if <paramref name="id"/> is <c>null</c>.
        /// </exception>
        public UserDTO GetUserById(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return _mapper.Map<UserDTO>
                (_unitOfWork.UserProfileRepository.FindBy(profile => profile.ApplicationUser.Id == id));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
