using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Domain.Services;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public HomeController(IArticleService articleService, ICommentService commentService, IMapper mapper)
        {
            _articleService = articleService;
            _commentService = commentService;
            _mapper = mapper;
        }
      
        public ActionResult Index()
        {
            return View();
        }
   
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }
 
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            string authUserId = AuthenticationManager.User.Identity.GetUserId();
            ProfileViewModel profileModel = _mapper.Map<ProfileViewModel>(UserService.GetUserById(authUserId));
            profileModel.ArticleViewModel =
                _mapper.Map<IEnumerable<ArticleViewModel>>(_articleService.GetByUserId(authUserId));
            return View(profileModel);
        }

    }
}