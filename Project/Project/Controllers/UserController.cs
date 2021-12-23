using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfile()
        {
            return View();
        }

        public IActionResult UserMail()
        {
            return View();
        }
        
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult UserNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult UserFooterPartial()
        {
            return PartialView();
        }
    }
}
