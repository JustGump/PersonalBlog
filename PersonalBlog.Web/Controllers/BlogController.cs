using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Domain.Services;
using PersonalBlog.Web.AutoMapper;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.Controllers
{
    public class BlogController : Controller
    {
        
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        // GET: Blog
        public ActionResult Index()
        {
            IEnumerable<BlogViewModel> allBlogsModel = _mapper.Map<IEnumerable<BlogViewModel>>(_blogService.GetAll());
            return View(allBlogsModel);
        }



    }
}