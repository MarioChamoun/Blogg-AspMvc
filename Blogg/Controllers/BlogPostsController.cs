using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    public class BlogPostsController : Controller
    {
        Blogcontext context = new Blogcontext();
        // GET: BlogPosts
        public ActionResult Index(string Type,string sort)
        {
            
            var allposts = context.posts.ToList();

            if (Type == null)
            {
                ViewData["DisplayAs"] = "normal";
            } else if(Type == "list")
            {
                ViewData["DisplayAs"] = "list";
            } else
            {
                ViewData["DisplayAs"] = "normal";
            }

            if (sort == "ASC")
            {
                allposts = context.posts.OrderBy(x => x.postDate).ToList();
            }
            else if (sort == "DESC")
            {
                allposts = context.posts.OrderByDescending(x => x.postDate).ToList();
            }
            ViewBag.categories = context.categories.Select(x => x.categoryTitle);


            return View(allposts);
        }
        public ActionResult Delete(int id)
        {
            var post = context.posts.SingleOrDefault(x => x.postID == id);
            context.posts.Remove(post);
            context.SaveChanges();
            return View(post);
        }
        public ActionResult ViewPost(int id)
        {
            var post = context.posts.Where(x => x.postID == id).ToList();
            return View(post);
        }
        public ActionResult search(string word)
        {
            Blogcontext context = new Blogcontext();
            var allposts = context.posts.Where(x => x.postTitle.Contains(word)).ToList();
            ViewBag.categories = context.categories.Select(x => x.categoryTitle);
            ViewData["DisplayAs"] = "list";

            return View("~/Views/BlogPosts/Index.cshtml", allposts);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var catnames = context.categories.Select(x => x.categoryTitle).ToList();
            ViewBag.categories = catnames;
            return View(new post());

        }
        [HttpPost]
        public ActionResult Create(post Post)
        {
            if (ModelState.IsValid)
            {
                Post.postDate = DateTime.Now;
                context.posts.Add(Post);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/BlogPosts/Create.cshtml", Post);
            }
        }
    }

}