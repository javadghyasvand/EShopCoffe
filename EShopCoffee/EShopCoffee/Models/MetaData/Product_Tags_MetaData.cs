using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{
    public class Product_Tags_MetaData
    {
        [Key]
        public long Tag_Id { get; set; }
        public long Product_Id { get; set; }
        public string Tag { get; set; }
    }
}