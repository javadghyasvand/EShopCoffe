using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopCoffee.Models
{
    public class Product_Comments_MetaData
    {
        [Key]
        public long Comment_Id { get; set; }
        

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(900,ErrorMessage ="تعداد کاراکتر ها بیشتر از 900 می باشد" )]
        public string Comment { get; set; }
    }
}