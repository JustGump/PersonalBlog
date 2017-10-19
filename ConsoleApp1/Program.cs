using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;
using PersonalBlog.Domain.AutoMapper;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Infrastructure;
using PersonalBlog.Domain.Services;

namespace ConsoleApp1
{
 

    class Program
    {
      
        static void Main(string[] args)
        {
            UserService service = new UserService(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);    
            UserDTO userDTO = new UserDTO();
            userDTO.Name = "Soko@cg.com";
            userDTO.Email = "Soko@cg.com";
            userDTO.Description = "Hi errbody";
            userDTO.Password = "Maze123@";
            userDTO.Role = "user";

            service.Create(userDTO);
            Console.WriteLine("done");
        }
    }
}
