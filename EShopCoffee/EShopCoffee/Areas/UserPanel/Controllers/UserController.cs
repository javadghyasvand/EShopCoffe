using EShopCoffee.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EShopCoffee.Models.DataLayer;

namespace EShopCoffee.Areas.UserPanel.Controllers
{
    public class UserController : Controller
    {
        // GET: UserPanel/Account
        readonly EShopCoffe_DBEntities _db = new EShopCoffe_DBEntities();

        // GET: UserPanel/Account
        public ActionResult ChangPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangPassword(ChangPasswordViewModel changPassword)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.Single(u => u.User_Name == User.Identity.Name);
                string oldpassword =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(changPassword.OldPassword, "MD5");
                if (user.User_Password == oldpassword)
                {
                    string hashNewPassword =
                        FormsAuthentication.HashPasswordForStoringInConfigFile(changPassword.Password, "MD5");
                    user.User_Password = hashNewPassword;
                    _db.SaveChanges();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "کلمه عبور فعلی درست نمی باشد");
                }
            }

            return View();
        }
    }
}