using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models.ViewModels
{
    public class ShopCartItem
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
    }

    public class ShopCartItemViewModel
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public int Count { get; set; }
    }

    public class ShowOrderViewModel
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public int Count { get; set; }
        public long ProductPrice { get; set; }
        public long DisCount { get; set; }
        public long Sum { get; set; }
    }

    public class AllOrderListViewModel
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsFinaly { get; set; }
        public List<long> TotalPrice { get; set; }
        public List<long> TotalDiscount { get; set; }
        public List<string> PictuerList { get; set; }
        public List<int> Count { get; set; }
        public List<long> ProductId { get; set; }
        public List<long> Price { get; set; }
        public List<string> ProductTitle { get; set; }
    }

}