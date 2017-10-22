using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Web.AutoMapper;
using PersonalBlog.Web.Models;
using WebGrease.Css.Extensions;

namespace PersonalBlog.Web.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ArticleController(IArticleService articleService, ICommentService commentService, IMapper mapper)
        {
            _articleService = articleService;
            _commentService = commentService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public ActionResult Index(int? blogId)
        {
            if (blogId != null)
            {
                IEnumerable<ArticleViewModel> articleModel = _mapper.Map<IEnumerable<ArticleViewModel>>(_articleService.GetByBlogId((int)blogId));
                return View(articleModel);
            }
            else
            {
                var allArticlesModel = _mapper.Map<IEnumerable<ArticleViewModel>>(_articleService.GetAll());
                return View(allArticlesModel);
            }
        }

        [AllowAnonymous]
        [ActionName("ByTag")]
        public ActionResult Index(string tagName)
        {
            IEnumerable<ArticleViewModel> articleModel = _mapper.Map<IEnumerable<ArticleViewModel>>(_articleService.GetByTagName(tagName));
            return View("Index", articleModel);
        }

        [AllowAnonymous]
        public ActionResult Show(int articleId)
        {
            ArticleViewModel articleModel = _mapper.Map<ArticleViewModel>(_articleService.GetById(articleId));
            return View(articleModel);
        }

 
        public ActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle(ArticleViewModel articleModel, string tagList)
        {
            if (ModelState.IsValid)
            {
                articleModel.UserProfileId = AuthenticationManager.User.Identity.GetUserId();
                articleModel.Date = DateTime.Now;
                if (!tagList.IsNullOrWhiteSpace())
                {
                    articleModel.Tags = new List<string>(tagList.Split(' '));
                }
                _articleService.Create(_mapper.Map<ArticleDTO>(articleModel));
                return RedirectToAction("Index");
            }
            else
            {
                return View(articleModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentArticle(int articleId, string commentBody)
        {
            CommentDTO newComment = new CommentDTO()
            {
                Body = commentBody,
                ArticleId = articleId,
                UserId = AuthenticationManager.User.Identity.GetUserId(),
            };
            _commentService.Create(newComment);
            return RedirectToAction("Show", "Article", new { articleId });
        }
    }
}