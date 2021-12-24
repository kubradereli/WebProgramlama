using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class RegisterController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User u)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(u);
            if (results.IsValid)
            {
                u.UserStatus = true;
                u.UserAbout = "deneme test";
                um.TAdd(u);
                return RedirectToAction("Index", "Activity");
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
    }
}
