using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;
using EShopCoffee.Models.ViewModels;
using MyShop;

namespace EShopCoffee.Controllers
{
    public class ProductController : Controller
    {
        private readonly EShopCoffe_DBEntities _dbEntities = new EShopCoffe_DBEntities();

        public ActionResult ShowGroups()
        {
            var productGroups = _dbEntities.Product_Groups.Where(g => g.Parent_Id==null).ToList();
            return PartialView(productGroups);
        }
        public ActionResult LastProduct()
        {
            var products = _dbEntities.Product_EShop.OrderByDescending(p => p.Product_CreateDate).Take(10);
            return PartialView(products);
        }

        [Route("ShowProduct/{id}")]
        public ActionResult ShowProduct(long id)
        {
            var product = _dbEntities.Product_EShop.Find(id);
            ViewBag.tags = _dbEntities.Product_Tags.Where(t => t.Product_Id == product.Product_Id);
            ViewBag.ProductFeatuer = product.Product_Proerty_Select.DistinctBy(f => f.Product_Proerty_Id).Select(f =>
                new ShowProductPropViewModel()
                {
                    TitleProp = f.Product_Property.Property_Title,
                    Value = _dbEntities.Product_Proerty_Select.Where(fe => fe.Product_Proerty_Id == f.Product_Proerty_Id).Select(fe => fe.Value).ToList()
                }).ToList();
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
        public ActionResult ShowComments(long id)
        {
            return PartialView(_dbEntities.Product_Comments.Where(p => p.Product_Id == id).Take(10));
        }
        public ActionResult CreateComment(int id)
        {
         
                return PartialView(new Product_Comments()
                {
                    Product_Id = id,
                });
        }
        [HttpPost]
        public ActionResult CreateComment(Product_Comments productComment)
        {
            if (ModelState.IsValid)
            {
                var user = _dbEntities.Users.Single(u => u.User_Email == User.Identity.Name);
                productComment.Email = user.User_Email;
                productComment.Name = user.User_Name;
                productComment.UserId=user.User_Id;
                productComment.UserImage = user.User_Image;
                productComment.CommentDate = DateTime.Now;
                
                _dbEntities.Product_Comments.Add(productComment);
                _dbEntities.SaveChanges();
                return PartialView("ShowComments", _dbEntities.Product_Comments.Where(p => p.Product_Id == productComment.Product_Id));
            }

            return PartialView(productComment);
        }
        [Route("ArchiveProduct")]
        public ActionResult ArchiveProduct(int pageId = 1, string title = "", int minPrice = 0, int maxPrice = 0,
            List<int> selectGroup = null,string sortBy="")
        {
            ViewBag.groups = _dbEntities.Product_Groups.ToList();
            ViewBag.productTitle = title;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.selectGroup = selectGroup;
            ViewBag.pageId = pageId;
            ViewBag.sortBy = sortBy;
            List<Product_EShop> list = new List<Product_EShop>();
            if (selectGroup != null && selectGroup.Any())
            {
                foreach (int group in selectGroup)
                {
                    list.AddRange(_dbEntities.Product_Select_Groups.Where(g => g.Group_Id == group)
                        .Select(p => p.Product_EShop).ToList());
                }

                list = list.Distinct().ToList();
            }
            else
            {
                list.AddRange(_dbEntities.Product_EShop.ToList());
            }

            if (title != "")
            {
                list = list.Where(p => p.Proudct_Title.Contains(title)).ToList();
            }

            if (minPrice > 0)
            {
                list = list.Where(p => p.Product_Price >= minPrice).ToList();
            }

            if (maxPrice > 0)
            {
                list = list.Where(p => p.Product_Price <= maxPrice).ToList();
            }
            //paging
            int take = 9;
            int skip = (pageId - 1) * take;
            ViewBag.pagecount = list.Count / take;
           
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "LastProduct":
                        return View(list.OrderByDescending(p => p.Product_CreateDate).Skip(skip).Take(take).ToList());
                    case "LowPrice":
                        return View(list.OrderBy(p => p.Product_Price).Skip(skip).Take(take).ToList());
                    case "HightPrice":
                        return View(list.OrderByDescending(p => p.Product_Price).Skip(skip).Take(take).ToList());
                }
            }

            return View(list.OrderByDescending(p => p.Product_CreateDate).Skip(skip).Take(take).ToList());
        }

        
    }
}