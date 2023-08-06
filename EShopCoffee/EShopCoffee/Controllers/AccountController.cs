using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using EShopCoffee.Models.DataLayer;
using EShopCoffee.Models.ViewModels;
using MyShop;

namespace EShopCoffee.Controllers
{
    public class AccountController : Controller
    {
        private readonly EShopCoffe_DBEntities _db = new EShopCoffe_DBEntities();

       


        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnurl = "/")
        {
            if (ModelState.IsValid)
            {
                var HashPassword =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(loginViewModel.User_Password, "MD5");
                var user =  _db.Users.SingleOrDefault(u =>
                    u.User_Email == loginViewModel.User_Email && u.User_Password == HashPassword);
                if (user != null)
                {
                    if (user.User_IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(user.User_Email, loginViewModel.Remember);
                        return Redirect(returnurl);
                    }
                    else
                    {
                        ModelState.AddModelError("User_Email",
                            "لطفا  با ورود به ایمیل" + @user.User_Email + " حساب کاربری خود را فعال کنید");
                    }
                }
                else
                {
                    ModelState.AddModelError("User_Email", "کابری با اطلاعات وارد شده یافت نشد");
                }
            }

            return View();
        }

        // GET: Account
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register")]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (!_db.Users.Any(u => u.User_Email == register.User_Email.Trim().ToLower()))
                {

                    Users user = new Users()
                    {
                        User_Email = register.User_Email.Trim().ToLower(),
                        User_Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.User_Password, "MD5"),
                        User_Active_Code = Guid.NewGuid().ToString(),
                        User_RegisterDate = DateTime.Now,
                        User_IsActive = false,
                        User_Role_Id = 3,
                        User_Name = register.User_Name,
                        User_Phone = register.User_Phone,
                        User_Image = "no-photo.jpg",
                        
                    };
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    //send Active Email
                    string body = PartialToStringClass.RenderPartialView("ManegeEmails", "ActiveEmail", user);
                    SendEmail.Send(user.User_Email, "ایمیل فعال سازی", body);
                    //End Active Email
                    return View("RegisterSuccess", user);
                }
                else
                {
                    ModelState.AddModelError("User_Email", "ایمیل وارد شده تکراری است");
                }
            }

            return View(register);
        }

        public ActionResult ActiveUser(string id)
        {
            var user = _db.Users.SingleOrDefault(u => u.User_Active_Code == id);
            if (user == null)
            {
                return View("NotFound");
            }

            ViewBag.UserName = user.User_Name;
            user.User_IsActive = true;
            user.User_Active_Code = Guid.NewGuid().ToString();
            _db.SaveChanges();
            return View();
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgotViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.SingleOrDefault(u => u.User_Email == forgotViewModel.User_Email);
                if (user != null)
                {
                    if (user.User_IsActive)
                    {
                        string bodyEmail =
                            PartialToStringClass.RenderPartialView("ManegeEmails", "RecoveryPassword", user);
                        SendEmail.Send(user.User_Email, "بازیابی کلمه عبور", bodyEmail);
                        return View("ForgotSuccess", user);
                    }
                    else
                    {
                        ModelState.AddModelError("User_Email", "حساب کاربری شما فعال نیست");
                    }
                }
                else
                {
                    ModelState.AddModelError("User_Email", "کاربری با این ایمیل یافت نشد");
                }
            }

            return View();
        }
        public ActionResult RecoveryPassword(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecoveryPassword(string id, RecoveryPasswordViewModel recoveryPassWordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.SingleOrDefault(u => u.User_Active_Code == id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.User_Password =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(recoveryPassWordViewModel.Password, "MD5");
                user.User_Active_Code = Guid.NewGuid().ToString();
                _db.SaveChanges();
                return Redirect("/Login?recovery=true");
            }
            return View();
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
