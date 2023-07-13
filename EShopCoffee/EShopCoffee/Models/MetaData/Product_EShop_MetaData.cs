using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Xml.Linq;

namespace EShopCoffee.Models
{
    public class Product_EShop_MetaData
    {
        [Key] public long Product_Id { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Proudct_Title { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public long Product_Count { get; set; }


        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public bool Product_IsInStock { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Product_Discription { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Product_Price { get; set; }
        [Display(Name = "تصویر")] public string Product_ImageName { get; set; }

        [Display(Name = "تاریخ")] public System.DateTime Product_CreateDate { get; set; }
        [Display(Name = "حذف")] public bool Product_Is_Delete { get; set; }
    }
}