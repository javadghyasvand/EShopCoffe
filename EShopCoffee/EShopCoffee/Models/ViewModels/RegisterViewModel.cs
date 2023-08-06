using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopCoffee.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string User_Name { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمی باشد")]
        public string User_Email { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        public string User_Phone { get; set; }

        [Display(Name = "کلمه ورود")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [StringLength(16,MinimumLength = 6,ErrorMessage = "تعداد کاراکتر رمز باید بین 6 تا 16 رقم باشد")]
        public string User_Password { get; set; }

        [Display(Name = "تکرار کلمه ورود")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("User_Password", ErrorMessage = "کلمه عبور مغایرت دارد")]
        public string ConfirmPassword { get; set; }

    }
}