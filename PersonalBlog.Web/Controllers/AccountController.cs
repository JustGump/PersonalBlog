using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Domain.Infrastructure;
using PersonalBlog.Domain.Interfaces;
using PersonalBlog.Web.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlog.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        // GET: Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            await SetInitialDataAsync();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserDTO userDTO = new UserDTO();
            userDTO.Email = model.Email;
            userDTO.Password = model.Password;
            ClaimsIdentity claim = await UserService.Authenticate(userDTO);
            if (claim == null)
            {
                AddErrors(new OperationDetails(false, "Uncorrect password or email", ""));
            }
            else
            {
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = true
                }, claim);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
             await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Password = model.Password,
                    Role = "user"
                }; // +passworl role
                var result = await UserService.CreateAsync(userDTO); // ! async

                if (result.Succeeded)
                {
                    
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("About", "Home");
                }
                //ModelState.AddModelError(result.Property, result.Message); //operationdetails
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
        
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }


        #region Helpers

        private void AddErrors(OperationDetails details)
        {
            ModelState.AddModelError(details.Property, details.Message);
        }

        #endregion
    }
}