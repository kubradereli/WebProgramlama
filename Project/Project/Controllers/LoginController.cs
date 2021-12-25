using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User u)
        {
            Context c = new Context();
            var dataValue = c.Users.FirstOrDefault(x => x.UserMail==u.UserMail && x.UserPassword == u.UserPassword);
            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,u.UserMail)
                };
                var userIdentitiy = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentitiy);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }
    }
}

//Context c = new Context();
//var dataValue = c.Users.FirstOrDefault(x => x.UserMail == u.UserMail && x.UserPassword == u.UserPassword);
//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", u.UserMail);
//    return RedirectToAction("Index", "User");
//}
//else
//{
//    return View();
//}
