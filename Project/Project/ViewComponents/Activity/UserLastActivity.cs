using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewComponents.Activity
{
    public class UserLastActivity : ViewComponent
    {
        ActivityManager am = new ActivityManager(new EfActivityRepository());
        
        public IViewComponentResult Invoke()
        {
            var values = am.GetActivityListByUser(1);
            return View(values);
        }
    }
}
