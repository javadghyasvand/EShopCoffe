using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;

namespace EShopCoffee.Areas.Admin.Controllers
{
    public class Blog_PostController : Controller
    {
        private EShopCoffe_DBEntities db = new EShopCoffe_DBEntities();

        // GET: Admin/Blog_Post
        public ActionResult Index()
        {
            var blog_Post = db.Blog_Post.Include(b => b.Blog_Group);
            return View(blog_Post.ToList());
        }
        public ActionResult BlogPostList()
        {
            return PartialView(db.Blog_Post.ToList());
        }

        // GET: Admin/Blog_Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Post blog_Post = db.Blog_Post.Find(id);
            if (blog_Post == null)
            {
                return HttpNotFound();
            }
            return View(blog_Post);
        }

        // GET: Admin/Blog_Post/Create
        public ActionResult Create()
        {
            ViewBag.postId = new SelectList(db.Blog_Group, "GroupId", "GroupName");
            return View();
        }

        // POST: Admin/Blog_Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "postId,groupId,post_Title,post_ShortDiscription,post_Discription,post_Visit,post_datetime,post_Image,post_Video")] Blog_Post blog_Post)
        {
            if (ModelState.IsValid)
            {
                db.Blog_Post.Add(blog_Post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.postId = new SelectList(db.Blog_Group, "GroupId", "GroupName", blog_Post.postId);
            return View(blog_Post);
        }

        // GET: Admin/Blog_Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Post blog_Post = db.Blog_Post.Find(id);
            if (blog_Post == null)
            {
                return HttpNotFound();
            }
            ViewBag.postId = new SelectList(db.Blog_Group, "GroupId", "GroupName", blog_Post.postId);
            return View(blog_Post);
        }

        // POST: Admin/Blog_Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "postId,groupId,post_Title,post_ShortDiscription,post_Discription,post_Visit,post_datetime,post_Image,post_Video")] Blog_Post blog_Post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog_Post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.postId = new SelectList(db.Blog_Group, "GroupId", "GroupName", blog_Post.postId);
            return View(blog_Post);
        }

        // GET: Admin/Blog_Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Post blog_Post = db.Blog_Post.Find(id);
            if (blog_Post == null)
            {
                return HttpNotFound();
            }
            return View(blog_Post);
        }

        // POST: Admin/Blog_Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog_Post blog_Post = db.Blog_Post.Find(id);
            db.Blog_Post.Remove(blog_Post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
