using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    [AllowAnonymous]
    public class ActivityController : Controller
    {
        ActivityManager am = new ActivityManager(new EfActivityRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

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
            var values = am.GetListWithCategoryByUserAm(1);
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
            ActivityValidator av = new ActivityValidator();
            ValidationResult results = av.Validate(a);
            if (results.IsValid)
            {
                a.ActivityStatus = true;
                a.UserID = 1;
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
            a.UserID = 1;
            a.ActivityStatus = true;
            am.TUpdate(a);
            return RedirectToAction("ActivityListByUser");
        }
    }
}
