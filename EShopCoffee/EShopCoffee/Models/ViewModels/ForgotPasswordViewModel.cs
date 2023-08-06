using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopCoffee.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمی باشد")]
        public string User_Email { get; set; }
    }
}