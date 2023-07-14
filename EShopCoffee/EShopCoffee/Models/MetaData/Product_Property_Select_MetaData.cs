using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopCoffee.Models
{
    public class Product_Proerty_Select_MetaData
    {
        [Key]
        public long Product_Proerty_Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "محصول")]
        public long Product_Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ویژگی")]
        public long Property_Id { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مقدار")]
        public string Value { get; set; }
    }
}