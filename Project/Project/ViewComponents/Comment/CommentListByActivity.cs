using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewComponents.Comment
{
    public class CommentListByActivity : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke()
        {
            var values = cm.GetList(5);
            return View(values);
        }
    }
}
