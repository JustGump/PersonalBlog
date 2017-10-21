using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Web.AutoMapper;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
       
        public ArticleController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
            _mapper = new MapperConfiguration(expression => expression.AddProfile(new ViewModelMappingProfile())).CreateMapper();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = _mapper.Map<IEnumerable<ArticleViewModel>>(_articleService.GetAll());      
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Show(int articleId)
        {
            var model = _mapper.Map<ArticleViewModel>(_articleService.GetById(articleId));
            return View(model);
        }

        public ActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]  
        public ActionResult CreateArticle(ArticleViewModel articleModel)
        {         
            _articleService.Create(_mapper.Map<ArticleDTO>(articleModel));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CommentArticle(int articleId, string commentBody)
        {
            CommentDTO comment = new CommentDTO()
            {            
                Body = commentBody,
                ArticleId = articleId,          
                UserId = AuthenticationManager.User.Identity.GetUserId()
            };
            _commentService.Create(comment);

            return RedirectToAction("Show","Article", new { articleId });
        }
      
        
    }
}