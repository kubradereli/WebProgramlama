using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Activities.Count().ToString();
            ViewBag.v2 = c.Activities.Where(x => x.UserID == 1).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
