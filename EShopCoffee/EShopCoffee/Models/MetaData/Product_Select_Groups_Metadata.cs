using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{

    public class Product_Select_Groups_MetaData
    {
        [Key]
        public long Pro_Gro_Id { get; set; }
        public long Product_Id { get; set; }
        public long Group_Id { get; set; }
    }
}