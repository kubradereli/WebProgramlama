using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            Context c = new Context();
            var userName = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserName).FirstOrDefault();
            ViewBag.v2 = userName;
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

        [HttpGet]
        public IActionResult UserEditProfile()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var userValues = um.GetById(userID);
            return View(userValues);
        }

        [HttpPost]
        public IActionResult UserEditProfile(User u)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(u);
            if (results.IsValid)
            {
                um.TUpdate(u);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserAdd(AddProfileImage u)
        {
            User user = new User();
            if(u.UserImage != null)
            {
                var extension = Path.GetExtension(u.UserImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                u.UserImage.CopyTo(stream);
                user.UserImage = newImageName;
            }
            user.UserMail = u.UserMail;
            user.UserName = u.UserName;
            user.UserPassword = u.UserPassword;
            user.UserStatus = true;
            user.UserAbout = u.UserAbout;
            um.TAdd(user);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}