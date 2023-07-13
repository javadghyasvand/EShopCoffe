using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace EShopCoffee.Models
{

    public class Product_Groups_MetaData
    {
        [Key]
        public long Group_Id { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Group_Title { get; set; }

        public Nullable<long> Parent_Id { get; set; }
    }
}