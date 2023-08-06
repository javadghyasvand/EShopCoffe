using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopCoffee.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمی باشد")]
        public string User_Email { get; set; }

        [Display(Name = "کلمه ورود")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool Remember { get; set; }
    }
}