using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{
    public class Blog_Group_MetaData
    {
        [Key]
        public int GroupId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250,ErrorMessage = "تعداد کاراکتر مجاز 250 می باشد")]
        [Display(Name = "نام گروه")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر مجاز 250 می باشد")]
        [Display(Name = "توضیحات")]
        public string GroupShortDescription { get; set; }
    }
}