using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{
    public class PersntOff_MetaData
    {
        [Key]
        public long Off_Id { get; set; }
        [Required]
        public long Product_Id { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ شروع")]
        public System.DateTime Start_Date { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ پایان")]
        public System.DateTime End_Date { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "درصد تخفیف")]
        public int Persent_Off { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "منقضی شده")]
        public bool IsExpire { get; set; }
    }
}