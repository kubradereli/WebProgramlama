using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ActivityController : Controller
    {
        ActivityManager am = new ActivityManager(new EfActivityRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var values = am.GetActivityListWithCategory();
            return View(values);
        }

        public IActionResult ActivityReadAll(int id)
        {
            ViewBag.i = id;
            var values = am.GetActivityByID(id);
            return View(values);
        }

        public IActionResult ActivityListByUser()
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var values = am.GetListWithCategoryByUserAm(userID);
            return View(values);
        }

        public IActionResult ActivityListByAdmin()
        {
            var values = am.GetActivityListWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult ActivityAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult ActivityAdd(Activity a)
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            ActivityValidator av = new ActivityValidator();
            ValidationResult results = av.Validate(a);
            if (results.IsValid)
            {
                a.ActivityStatus = true;
                a.UserID = userID;
                am.TAdd(a);
                return RedirectToAction("ActivityListByUser", "Activity");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteActivity(int id)
        {
            var activityValue = am.GetById(id);
            am.TDelete(activityValue);
            return RedirectToAction("ActivityListByUser");
        }

        public IActionResult DeleteActivityAdmin(int id)
        {
            var activityValue = am.GetById(id);
            am.TDelete(activityValue);
            return RedirectToAction("ActivityListByAdmin");
        }

        [HttpGet]
        public IActionResult EditActivity(int id)
        {
            var activityValue = am.GetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(activityValue);
        }

        [HttpPost]
        public IActionResult EditActivity(Activity a)
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            a.UserID = userID;
            a.ActivityStatus = true;
            am.TUpdate(a);
            return RedirectToAction("ActivityListByUser");
        }
    }
}
