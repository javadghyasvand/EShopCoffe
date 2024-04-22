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
    public class Blog_GroupController : Controller
    {
        private EShopCoffe_DBEntities db = new EShopCoffe_DBEntities();

        // GET: Admin/Blog_Group
        public ActionResult Index()
        {  
            return View(db.Blog_Group.ToList());
        }

        // GET: Admin/Blog_Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Group blog_Group = db.Blog_Group.Find(id);
            if (blog_Group == null)
            {
                return HttpNotFound();
            }
            return View(blog_Group);
        }

        // GET: Admin/Blog_Group/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Blog_Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupName,GroupShortDescription,IsDeleted")] Blog_Group blog_Group)
        {
            if (ModelState.IsValid)
            {
                db.Blog_Group.Add(blog_Group);
                db.SaveChanges();
                return PartialView("BlogGroupsList", db.Blog_Group.ToList());
            }

            return PartialView(blog_Group);
        }

        // GET: Admin/Blog_Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Group blog_Group = db.Blog_Group.Find(id);
            if (blog_Group == null)
            {
                return HttpNotFound();
            }
            return PartialView(blog_Group);
        }

        // POST: Admin/Blog_Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupName,GroupShortDescription,IsDeleted")] Blog_Group blog_Group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog_Group).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("BlogGroupsList", db.Blog_Group.ToList());
            }
            return PartialView(blog_Group);
        }


        // GET: Admin/Blog_Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Group blog_Group = db.Blog_Group.Find(id);
            if (blog_Group == null)
            {
                return HttpNotFound();
            }
            blog_Group.IsDeleted = true;
            db.Entry(blog_Group);
            db.SaveChanges();
            return RedirectToAction("BlogGroupsList");
        }

        public ActionResult ShowBlog(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Group blog_Group = db.Blog_Group.Find(id);
            if (blog_Group == null)
            {
                return HttpNotFound();
            }
            blog_Group.IsDeleted = false;
            db.Entry(blog_Group);
            db.SaveChanges();
            return RedirectToAction("BlogGroupsList");
        }
        public ActionResult BlogGroupsList()
        {
            return PartialView(db.Blog_Group.ToList());
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
