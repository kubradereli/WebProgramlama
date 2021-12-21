using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ActivityController : Controller
    {
        ActivityManager am = new ActivityManager(new EfActivityRepository());

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
    }
}
