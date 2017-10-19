using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Domain.Services;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.Controllers
{
    public class BlogController : Controller
    {
        //private IBlogService _blogService => HttpContext.GetOwinContext().GetUserManager<IBlogService>();
        private readonly IBlogService _blogService;
        private readonly IArticleService _articleService;

        public BlogController(IBlogService blogService, IArticleService articleService)
        {
            _blogService = blogService;
            _articleService = articleService;
        }
        // GET: Blog
        public ActionResult Index()
        {
            BlogViewModel model = new BlogViewModel();
            model.Blogs = _blogService.GetAll();
            return View(model);
        }
        
        public ActionResult Articles(string blogName = "NewTitle")
        {
            var a = _articleService.GetByBlog(blogName);
            return View(a);
        }
    }
}