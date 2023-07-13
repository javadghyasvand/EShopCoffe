using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{
    public class Product_Galllery_MetaData
    {
        [Key]
        public long Gallery_Id { get; set; }
        public long Product_Id { get; set; }
        [Display(Name = "تصویر")]
        public string Gallery_Image_Name { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Gallery_Image_Title { get; set; }
    }
}