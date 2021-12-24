using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewComponents.User
{
    public class UserAboutOnDashboard : ViewComponent
    {
        UserManager um = new UserManager(new EfUserRepository());

        public IViewComponentResult Invoke()
        {
            var values = um.GetUserById(1);
            return View(values);
        }
    }
}
