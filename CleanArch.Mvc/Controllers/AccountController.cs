using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
                return View();

            Domain.Models.User user=new User()
            {
                UserName = register.UserName,
                Email = register.Email,
                Password = PasswordHelper.EncodePasswordMd5(register.Password)
            };

            _userService.RegisterUser(user);

            return Redirect("/Course/Index");
        }

        #endregion

        #region Login

        public IActionResult Login(string ReturnUrl="/")
        {
            ViewBag.Return = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM login, string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View(login);

            if (!_userService.IsExistUser(login.Email, login.Password))
            {
                ModelState.AddModelError("Email","User Not Exist ...");
                return View(login);
            }

            var claim=new List<Claim>()
            {
                new Claim(ClaimTypes.Name, login.Email),
                new Claim(ClaimTypes.NameIdentifier, login.Email)
            };
            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal= new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = login.RememeberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect(ReturnUrl);
        }
        #endregion

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
