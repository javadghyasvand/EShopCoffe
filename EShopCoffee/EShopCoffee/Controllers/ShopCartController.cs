using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EShopCoffee.Models.ViewModels;

namespace EShopCoffee.Controllers
{
    public class ShopCartController : ApiController
    {
        // GET: api/ShopCart
        public int Get()
        {
            List<ShopCartItem> list = new List<ShopCartItem>();
            var session = HttpContext.Current.Session;
            if (session["ShopCart"] != null)
            {
                list = session["ShopCart"] as List<ShopCartItem>;
            }
            return list.Sum(l => l.Count);
        }

        // GET: api/ShopCart/5
        public int Get(int id)
        {
            List<ShopCartItem> list = new List<ShopCartItem>();
            var session = HttpContext.Current.Session;
            if (session["ShopCart"] != null)
            {
                list = session["ShopCart"] as List<ShopCartItem>;
            }
            if (list.Any(p => p.Product_Id == id))
            {
                int index = list.FindIndex(p => p.Product_Id == id);
                list[index].Count += 1;
            }
            else
            {
                list.Add(new ShopCartItem()
                {
                    Product_Id = id,
                    Count = 1
                });
            }
            session["ShopCart"] = list;
            return Get();
        }
    }
}