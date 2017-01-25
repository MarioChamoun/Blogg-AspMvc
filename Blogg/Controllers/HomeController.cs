using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Blogcontext context = new Blogcontext();
            var allcategories = context.categories.ToList();

            if(!context.categories.Any()){
                var cates = new List<category>()
                {
                    new category {categoryID = 1, categoryTitle = "Action" },
                    new category {categoryID = 2, categoryTitle = "Drama" },
                    new category {categoryID = 3, categoryTitle = "Komedi" },
                    new category {categoryID = 4, categoryTitle = "Skräck" }
                };
                foreach (var c in cates)
                {
                    context.categories.Add(c);
                }
                context.SaveChanges();
            }

            return View(allcategories);
        }
    }
}