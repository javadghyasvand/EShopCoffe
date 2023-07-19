using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{
    public class Users_MetaData
    {
        [Key]
        public long User_Id { get; set; }
        [Display(Name = "نقش کاربر")]
        public long User_Role_Id { get; set; }
        [Display(Name = "نام کاربری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string User_Name { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل شما نا معتبر می باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل شما نا معتبر می باشد")]
        public string User_Email { get; set; }
        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Phone(ErrorMessage = "شماره تماس راه به صورت صحیح وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        public string User_Phone { get; set; }
        [Display(Name = "رمز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password,ErrorMessage = "شماره تماس راه به صورت صحیح وارد کنید")]
        public string User_Password { get; set; }
        [Display(Name = "کد فعال سازی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string User_Active_Code { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool User_IsActive { get; set; }
        public System.DateTime User_RegisterDate { get; set; }
    }
}