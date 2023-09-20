using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models.ViewModels
{
    public class ShopCartItem
    {
        public long Product_Id { get; set; }
        public int Count { get; set; }
    }
    public class ShopCartItemViewModel
    {
        public long Product_Id { get; set; }
        public string Product_Title { get; set; }
        public string Product_Image { get; set; }
        public int Count { get; set; }
    }
    public class ShowOrderViewModel
    {
        public long Product_Id { get; set; }
        public string Product_Title { get; set; }
        public string Product_Image { get; set; }
        public int Count { get; set; }
        public long Product_Price { get; set; }
        public long DisCount { get; set; }
        public long Sum { get; set; }
        public long PriceTotal { get; set; }
    }
}