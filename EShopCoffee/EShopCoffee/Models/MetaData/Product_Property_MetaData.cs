using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopCoffee.Models
{
    public class Product_Property_MetaData
    {
        [Key]
        public long Property_Id { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان ویژگی")]
        public string Property_Title { get; set; }
    }
}