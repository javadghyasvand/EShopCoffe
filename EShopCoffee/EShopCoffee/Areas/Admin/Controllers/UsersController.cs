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
    public class UsersController : Controller
    {
        private EShopCoffe_DBEntities db = new EShopCoffe_DBEntities();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Roles);
            return View(users.ToList());
        }
        public ActionResult Navbar()
        {
            return PartialView();
        }
        // GET: Admin/Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Title");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_Id,User_Role_Id,User_Name,User_Email,User_Phone,User_Password,User_Active_Code,User_IsActive,User_RegisterDate,User_Image")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Title", users.User_Role_Id);
            return View(users);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit([Bind(Include = "User_Id,User_Role_Id,User_Name,User_Email,User_Phone,User_Password,User_Active_Code,User_IsActive,User_RegisterDate,User_Image")] long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Title", users.User_Role_Id);
            return View(users);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_Id,User_Role_Id,User_Name,User_Email,User_Phone,User_Password,User_Active_Code,User_IsActive,User_RegisterDate,User_Image")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Title", users.User_Role_Id);
            return View(users);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
