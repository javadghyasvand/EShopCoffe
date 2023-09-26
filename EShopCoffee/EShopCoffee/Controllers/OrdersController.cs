using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopCoffee.Models.DataLayer;
using EShopCoffee.Models.ViewModels;
using MyShop.Utilities;

namespace EShopCoffee.Controllers
{
    public class OrdersController : Controller
    {
        private readonly EShopCoffe_DBEntities _dbEntities = new EShopCoffe_DBEntities();

        List<AllOrderListViewModel> GetListOrders(long? userid)
        {
            List<AllOrderListViewModel> showOrders = new List<AllOrderListViewModel>();
            List<Order> listOrder;
            listOrder = _dbEntities.Order.Where(o => o.UserID == userid).ToList();
            foreach (var item in listOrder)
            {
                if (_dbEntities.OrderDetails.Any(o => o.OrderId == item.OrderID))
                {
                    showOrders.Add(new AllOrderListViewModel()
                    {
                        OrderId = item.OrderID,
                        OrderDate = item.OrderDate,
                        IsFinaly = item.IsFinaly,
                        Count =_dbEntities.OrderDetails.Where(o => o.OrderId == item.OrderID).Select(p => p.Count).ToList(),
                        ProductId= _dbEntities.OrderDetails.Where(o => o.OrderId == item.OrderID).Select(p => p.ProductID).ToList(),
                        TotalPrice = _dbEntities.OrderDetails.Where(o => o.OrderId == item.OrderID)
                            .Select(p => p.TotalPrice).ToList(),
                        TotalDiscount = _dbEntities.OrderDetails.Where(o => o.OrderId == item.OrderID)
                            .Select(p => p.Discountprice).ToList(),
                        PictuerList = _dbEntities.OrderDetails.Where(o => o.OrderId == item.OrderID)
                            .Select(p => p.ProductImage).ToList(),
                        Price = _dbEntities.OrderDetails.Where(o => o.OrderId == item.OrderID)
                            .Select(p => p.Price).ToList(),
                    });
                }
            }

            return showOrders;
        }

        // GET: Orders
        public ActionResult Index(long id)
        {
            var detailList = GetListOrders(id);
            return View(detailList);
        }

        public ActionResult OrderList(AllOrderListViewModel listViewModel)
        {
            return PartialView(listViewModel);
        }

        //GET: Orders/OrderShow/5
        public ActionResult OrderShow(long? id)
        {
            ViewBag.order = _dbEntities.Order.Single(o => o.OrderID ==id);
            var  orderDetails = _dbEntities.OrderDetails.Where(o => o.OrderId == id).ToList();
            return View(orderDetails);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbEntities.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}