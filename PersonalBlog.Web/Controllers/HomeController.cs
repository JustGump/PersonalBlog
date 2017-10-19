using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Domain.Services;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.Controllers
{
    public class HomeController : Controller
    {    
      
        public ActionResult Index()
        {

            
            return View();
        }
        //GET:
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

      //  [Authorize]
     /*   public ActionResult CreateBlog()
        {
            ViewBag.Message = "CreateBlog";
            return View();
        }*/
/*
        [HttpPost]
       // [Authorize]
        public ActionResult CreateBlog(BlogViewModel model)
        {
           var id = User.Identity.GetUserId();
            BlogService.Create(model.Title, model.Description, id);
            
            return View();
        }
*/
    }
}