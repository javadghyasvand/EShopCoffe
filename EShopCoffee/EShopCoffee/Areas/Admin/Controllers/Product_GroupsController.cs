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
    public class Product_GroupsController : Controller
    {
        private readonly EShopCoffe_DBEntities _db = new EShopCoffe_DBEntities ();

        // GET: Admin/Product_Groups
        public ActionResult Index()
        {
            var productGroups = _db.Product_Groups.Include(p => p.Product_Groups2);
            return View(productGroups.ToList());
        }

        // GET: Admin/Product_Groups/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Groups productGroups = _db.Product_Groups.Find(id);
            if (productGroups == null)
            {
                return HttpNotFound();
            }
            return View(productGroups);
        }

        // GET: Admin/Product_Groups/Create
        public ActionResult Create(int? id)

        {
            if (id!=null)
            {
                var group = _db.Product_Groups.Find(id);
                ViewBag.parentId = group.Group_Id;
            }
            return View();
        }

        // POST: Admin/Product_Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Group_Id,Group_Title,Parent_Id")] Product_Groups productGroups)
        {
            if (ModelState.IsValid)
            {
                _db.Product_Groups.Add(productGroups);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var group = _db.Product_Groups.Find(productGroups.Group_Id);
            ViewBag.parentId = group.Group_Id;
            return View(productGroups);
        }

        // GET: Admin/Product_Groups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Groups productGroups = _db.Product_Groups.Find(id);
            if (productGroups == null)
            {
                return HttpNotFound();
            }
            return View(productGroups);
        }

        // POST: Admin/Product_Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Group_Id,Group_Title,Parent_Id")] Product_Groups productGroups)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(productGroups).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productGroups);
        }

        // GET: Admin/Product_Groups/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Groups productGroups = _db.Product_Groups.Find(id);
            if (productGroups == null)
            {
                return HttpNotFound();
            }
            return View(productGroups);
        }

        // POST: Admin/Product_Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product_Groups productGroups = _db.Product_Groups.Find(id);
            _db.Product_Groups.Remove(productGroups);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListGroups()
        {
            return PartialView(_db.Product_Groups.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
