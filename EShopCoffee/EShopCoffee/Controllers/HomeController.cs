using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;
using EShopCoffee.Models.ViewModels;
using InsertShowImage;
using KooyWebApp_MVC.Classes;

namespace EShopCoffee.Controllers
{
    public class HomeController : Controller
    {
        readonly EShopCoffe_DBEntities _db = new EShopCoffe_DBEntities();

        public ActionResult Slider()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult UserProfile(long id)
        {
            var user = _db.Users.Find(id);


            return View(user);
        }

        public ActionResult EditProfile(long id)
        {
            var user = _db.Users.Find(id);
            UserProfileViewModel viewModel = new UserProfileViewModel()
            {
                User_Id = user.User_Id,
                User_Email = user.User_Email,
                User_Name = user.User_Name,
                User_Image = user.User_Image,
                User_Phone = user.User_Phone,
                User_State_ID = user.User_State_ID,
                User_City_ID = user.User_City_ID,
                User_Postal_Code = user.User_Postal_Code,
                User_Address = user.User_Address
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(
            [Bind(Include =
                "User_Id,User_Name,User_Email,User_Phone,User_Image,User_State_ID,User_City_ID,User_Address,User_Postal_Code")]
            UserProfileViewModel users, HttpPostedFileBase imageProduct)
        {
            if (ModelState.IsValid)
            {
                var state = _db.tblOstan.Find(users.User_State_ID);
                var city = _db.tblShahrestan.Find(users.User_City_ID);
                if (imageProduct != null && imageProduct.IsImage())
                {
                    if (users.User_Image != "no-photo.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/UserImge/" + users.User_Image));
                        System.IO.File.Delete(Server.MapPath("/Images/UserImge/Thumbnail/" + users.User_Image));
                    }

                    users.User_Image = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/UserImge/" + users.User_Image));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Images/UserImge/" + users.User_Image),
                        Server.MapPath("/Images/UserImge/Thumbnail/" + users.User_Image));
                }
                var userEdit = _db.Users.Find(users.User_Id);

                if (userEdit != null)
                {
                    userEdit.User_Email = users.User_Email;
                    userEdit.User_Name = users.User_Name;
                    userEdit.User_Phone = users.User_Phone;
                    userEdit.User_Image = users.User_Image;
                    userEdit.User_State_ID = users.User_State_ID;
                    userEdit.User_City_ID = users.User_City_ID;
                    userEdit.User_State_Name = state.Ostan;
                    userEdit.User_City_Name = city.Shahrestan;
                    userEdit.User_Address = users.User_Address;
                    userEdit.User_Postal_Code = users.User_Postal_Code;
                    _db.Entry(userEdit).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("UserProfile", "Home", new { id = users.User_Id } );
                }

            }
            else if (users.User_State_ID == null || users.User_City_ID == null)
            {
                if (users.User_State_ID == null)
                {
                    ModelState.AddModelError("User_State_ID", "لطفا استان را انتخاب کنید");
                    return View(users);
                }
                else
                {
                    ModelState.AddModelError("User_City_ID", "لطفا شهر را انتخاب کنید");
                    return View(users);
                }
            }

            return View(users);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}