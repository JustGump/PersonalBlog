using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
       
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var a = _articleService.GetAll();
            return View(a);
        }
        
        public ActionResult CreateArticle()
        {        
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]  
        public ActionResult CreateArticle(ArticleViewModel articleModel)
        {
            ArticleDTO article = new ArticleDTO()
            {
                Title = articleModel.Title,
                Body = articleModel.Body,
                BlogTitle = articleModel.BlogTitle,        
                UserProfileId = AuthenticationManager.User.Identity.GetUserId()
            };
            _articleService.Create(article);

            return RedirectToAction("Index");
        }

      
        
    }
}