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
    public class Product_PropertyController : Controller
    {
        private readonly EShopCoffe_DBEntities _db = new EShopCoffe_DBEntities();

        // GET: Admin/Product_Property
        public ActionResult Index()
        {
            return View(_db.Product_Property.ToList());
        }
        // GET: Admin/Product_Property/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Property productProperty = _db.Product_Property.Find(id);
            if (productProperty == null)
            {
                return HttpNotFound();
            }
            return View(productProperty);
        }

        // GET: Admin/Product_Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product_Property/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Property_Title")] Product_Property productProperty)
        {
            if (ModelState.IsValid)
            {
                _db.Product_Property.Add(productProperty);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productProperty);
        }

        // GET: Admin/Product_Property/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Property productProperty = _db.Product_Property.Find(id);
            if (productProperty == null)
            {
                return HttpNotFound();
            }
            return View(productProperty);
        }

        // POST: Admin/Product_Property/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Property_Id,Property_Title")] Product_Property productProperty)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(productProperty).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productProperty);
        }

        // GET: Admin/Product_Property/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Property productProperty = _db.Product_Property.Find(id);
            if (productProperty == null)
            {
                return HttpNotFound();
            }
            return View(productProperty);
        }

        // POST: Admin/Product_Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product_Property productProperty = _db.Product_Property.Find(id);
            _db.Product_Property.Remove(productProperty);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
