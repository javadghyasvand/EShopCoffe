using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using EShopCoffee.Models.DataLayer;
using InsertShowImage;
using KooyWebApp_MVC.Classes;


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
            return View(new Product_Groups()
            {
                Parent_Id = id
            });

         }

        // POST: Admin/Product_Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Group_Id,Group_Title,Parent_Id,Group_Image")] Product_Groups productGroups,HttpPostedFileBase imageProduct)
        {

            if (ModelState.IsValid)
            {
                productGroups.Group_Image = "LogoEN.png";
                if (imageProduct != null && imageProduct.IsImage())
                {

                    if (productGroups.Group_Image != "LogoEN.png")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/ProductGroups/" + productGroups.Group_Image));
                        System.IO.File.Delete(Server.MapPath("/Images/ProductGroups/Thumbnail/" + productGroups.Group_Image));
                    }
                    productGroups.Group_Image = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductGroups/" + productGroups.Group_Image));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Images/ProductGroups/" + productGroups.Group_Image),
                        Server.MapPath("/Images/ProductGroups/Thumbnail/" + productGroups.Group_Image));
                }
                _db.Product_Groups.Add(productGroups);
                _db.SaveChanges();
                return RedirectToAction("Index", _db.Product_Groups.Include(p => p.Product_Groups2));
            }

            return View(productGroups);
        }

        // GET: Admin/Product_Groups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Groups product_Groups = _db.Product_Groups.Find(id);
            if (product_Groups == null)
            {
                return HttpNotFound();
            }

            return View(product_Groups);
        }

        // POST: Admin/Product_Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Group_Id,Group_Title,Parent_Id,Group_Image")] Product_Groups productGroups, HttpPostedFileBase imageProduct)
        {
          

            if (ModelState.IsValid)
            {
                if (imageProduct != null && imageProduct.IsImage())
                {

                    if (productGroups.Group_Image != "LogoEN.png")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/ProductGroups/" + productGroups.Group_Image));
                        System.IO.File.Delete(Server.MapPath("/Images/ProductGroups/Thumbnail/" + productGroups.Group_Image));
                    }
                    productGroups.Group_Image = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductGroups/" + productGroups.Group_Image));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Images/ProductGroups/" + productGroups.Group_Image),
                        Server.MapPath("/Images/ProductGroups/Thumbnail/" + productGroups.Group_Image));
                }
                _db.Entry(productGroups).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", _db.Product_Groups.Include(p => p.Product_Groups2));
            }
            return View(productGroups);
        }

        // GET: Admin/Product_Groups/Delete/5
        public ActionResult Delete(int? id)
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
        public void DeleteGroups(int id)
        {
            var groups = _db.Product_Groups.Find(id);
            if (groups != null) _db.Product_Groups.Remove(groups);
            _db.SaveChanges();

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
