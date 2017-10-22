using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Infrastructure;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        //Task SetInitialData(UserDTO adminDto, List<string> roles);
        UserDTO GetUserById(string id);
    }
}
