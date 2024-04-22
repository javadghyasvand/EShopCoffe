using System;
using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models.DataLayer
{
    internal class Blog_Post_MetaData
    {
        [Key]
        public int postId { get; set; }
        [Display(Name = "گروه")]
        public int groupId { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(350, ErrorMessage = "تعداد حروف بیش از حدمجاز است")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string post_Title { get; set; }

        [Display(Name = "توضیح کوتاه")]
        [MaxLength(255,ErrorMessage = "تعداد حروف بیش از حدمجاز است")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string post_ShortDiscription { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string post_Discription { get; set; }
        [Display(Name = "نعداد بازدید")]
        public Nullable<int> post_Visit { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public Nullable<System.DateTime> post_datetime { get; set; }
        [Display(Name = "عکس")]
        [MaxLength(550, ErrorMessage = "تعداد حروف بیش از حدمجاز است")]
        public string post_Image { get; set; }
        [Display(Name = "ویدیو")]
        [MaxLength(550, ErrorMessage = "تعداد حروف بیش از حدمجاز است")]
        public string post_Video { get; set; }



        public virtual Blog_Group Blog_Group { get; set; }
    }
}