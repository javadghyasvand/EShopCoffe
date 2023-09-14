using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;

namespace EShopCoffee.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        readonly EShopCoffe_DBEntities _dbEntities = new EShopCoffe_DBEntities();
        // GET: Search
        public ActionResult Index(string q)
        {
            List<Product_EShop> products = new List<Product_EShop>();
            products.AddRange(_dbEntities.Product_Tags.Where(t => t.Tag == q).Select(p => p.Product_EShop).ToList());
            products.AddRange(_dbEntities.Product_EShop.Where(p => p.Proudct_Title.Contains(q) || p.Product_Discription.Contains(q)).ToList());
            ViewBag.Search = q;
            return View(products.Distinct());
        }
    }
}