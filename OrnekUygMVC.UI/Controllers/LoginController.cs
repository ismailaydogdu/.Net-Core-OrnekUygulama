using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekUyg.Model;
using OrnekUyg.BLL.Abstract;
using Newtonsoft.Json;

namespace OrnekUygMVC.UI.Controllers
{

    public class LoginController : Controller
    {
        IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            User user = new User();
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {

                user.UserName = Request.Cookies["username"].ToString();
                user.Password = Request.Cookies["password"].ToString();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Index(User user, bool remember)
        {
            HttpContext.Session.SetString("LoginSession", JsonConvert.SerializeObject(null));
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(15);
            if (remember)
            {

                Response.Cookies.Append("username", user.UserName, cookie);
                Response.Cookies.Append("password", user.Password, cookie);
            }
            User loginUser;
            try
            {
                loginUser = _userService.Login(user.UserName, user.Password);
            }
            catch (Exception ex)
            {
                ViewBag.Ex = ex.Message;
                return View();
            }
            HttpContext.Session.SetString("LoginSession", JsonConvert.SerializeObject(loginUser));
            return RedirectToAction("Index", "Home");

        }
    }
}