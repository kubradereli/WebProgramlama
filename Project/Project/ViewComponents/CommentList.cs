using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Ali"
                },
                new UserComment
                {
                    ID = 2,
                    Username = "Mehmet"
                },
                new UserComment
                {
                    ID = 3,
                    Username = "Merve"
                }
            };
            return View(commentvalues);
        }
    }
}
