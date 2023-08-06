using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;
using EShopCoffee.Models.ViewModels;

namespace EShopCoffee.Controllers
{
    public class HomeController : Controller
    {
        EShopCoffe_DBEntities _db = new EShopCoffe_DBEntities();
        public ActionResult Welcome()
        {
            return PartialView();
        }
        public ActionResult LoggedInUser()
        {
        
            return PartialView();
        }
        public ActionResult Navbar()
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
            UserProfileViewModel profileViewModel = new UserProfileViewModel();
            if (_db.User_Details.Any(d => d.User_Id == id))
            {
                var user_detailes = _db.User_Details.Single(d => d.User_Id == id);
                profileViewModel.User_Id = user.User_Id;
                profileViewModel.User_Email = user.User_Email;
                profileViewModel.User_Name = user.User_Name;
                profileViewModel.User_Phone = user.User_Phone;
                profileViewModel.User_Image = user.User_Image;
                profileViewModel.User_Phone = user_detailes.User_Address;
                profileViewModel.User_Detail_Id = user_detailes.User_Detail_Id;
                profileViewModel.User_City = user_detailes.User_City;
                profileViewModel.User_Postal_Code = user_detailes.User_Postal_Code;
                profileViewModel.User_State = user_detailes.User_State;


            }
            else
            {
                profileViewModel.User_Id = user.User_Id;
                    profileViewModel.User_Email = user.User_Email;
                    profileViewModel.User_Name = user.User_Name;
                    profileViewModel.User_Phone = user.User_Phone;
                    profileViewModel.User_Image = user.User_Image;
                    profileViewModel.User_Address ="ثبت نشد";
                    profileViewModel.User_City = "ثبت نشد";
                    profileViewModel.User_Postal_Code = "ثبت نشد"; 
                    profileViewModel.User_State = "ثبت نشد";
            }

            return View(profileViewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}