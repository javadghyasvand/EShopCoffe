using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;
using EShopCoffee.Models.ViewModels;

namespace MyShop.Controllers
{
    public class ShopItemsController : Controller
    {
        readonly EShopCoffe_DBEntities _dbEntities = new EShopCoffe_DBEntities();

        // GET: ShopItems
        public ActionResult ShowCart()
        {
            List<ShopCartItemViewModel> sales = new List<ShopCartItemViewModel>();
            if (Session["ShopCart"] != null)
            {
                List<ShopCartItem> shopCartItems = (List<ShopCartItem>)Session["ShopCart"];
                foreach (var item in shopCartItems)
                {
                    var product = _dbEntities.Product_EShop.Where(p => p.Product_Id == item.Product_Id).Select(p => new
                    {
                        p.Product_ImageName,
                        p.Proudct_Title
                    }).Single();
                    sales.Add(new ShopCartItemViewModel()
                    {
                        Product_Id = item.Product_Id,
                        Count = item.Count,
                        Product_Title = product.Proudct_Title,
                        Product_Image = product.Product_ImageName
                    });
                }
            }

            return PartialView(sales);
        }

        public ActionResult Index()
        {
            return View();
        }

        List<ShowOrderViewModel> GetListOrder()
        {
            List<ShowOrderViewModel> showOrders = new List<ShowOrderViewModel>();
            if (Session["ShopCart"] != null)
            {
                List<ShopCartItem> listShopCart = Session["ShopCart"] as List<ShopCartItem>;
                foreach (var item in listShopCart)
                {
                    var product = _dbEntities.Product_EShop.Single(P => P.Product_Id == item.Product_Id);
                    showOrders.Add(new ShowOrderViewModel()
                    {
                        Product_Id = item.Product_Id,
                        Count = item.Count,
                        Product_Image = product.Product_ImageName,
                        Product_Title = product.Proudct_Title,
                        Product_Price = product.Product_Price,
                        Sum = item.Count * product.Product_Price
                    });
                }
            }

            return showOrders;
        }

        public ActionResult Order()
        {
            return PartialView(GetListOrder());
        }

        public ActionResult CommandOrder(int id, int count)
        {
            List<ShopCartItem> listShopCart = Session["ShopCart"] as List<ShopCartItem>;
            int indx = listShopCart.FindIndex(p => p.Product_Id == id);
            if (count == 0)
            {
                listShopCart.RemoveAt(indx);
            }
            else
            {
                listShopCart[indx].Count = count;
            }

            Session["ShopCart"] = listShopCart;
            return PartialView("Order", GetListOrder());
        }

        [Authorize]
        public ActionResult Payment()
        {
            var userId = _dbEntities.Users.Single(u => u.User_Email == User.Identity.Name).User_Id;
            Order orders = new Order()
            {
                UserID = userId,
                OrderDate = DateTime.Now,
                IsFinaly = false,
            };
            _dbEntities.Order.Add(orders);
            var detailList = GetListOrder();
            foreach (var item in detailList)
            {
                _dbEntities.OrderDetails.Add(new OrderDetails()
                {
                    Count = item.Count,
                    OrderId = orders.OrderID,
                    ProductID = item.Product_Id,
                    Price = item.Product_Price,
                });
            }
            //Online Payment
            _dbEntities.SaveChanges();
            return null;
        }
    }
}