using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public long User_Id { get; set; }
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
        [Display(Name = "تصویر")]
        public string User_Image { get; set; }
        [DisplayName("آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string User_Address { get; set; }
        [DisplayName("استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string User_State { get; set; }
        [DisplayName("شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string User_City { get; set; }
        [DisplayName("کد پستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.PostalCode)]
        public string User_Postal_Code { get; set; }

        public long User_Detail_Id { get; set; }

    }

    public class UserProfileAdminViewModel
    {
        public long User_Id { get; set; }
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
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool User_IsActive { get; set; }
        [Display(Name = "نقش کاربر")]
        public string User_Role { get; set; }
        [Display(Name = "تصویر")]
        public string User_Image { get; set; }
        [DisplayName("آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string User_Address { get; set; }
        [DisplayName("استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string User_State { get; set; }
        [DisplayName("شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string User_City { get; set; }
        [DisplayName("کد پستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.PostalCode)]
        public string User_Postal_Code { get; set; }

        public long User_Detail_Id { get; set; }

    }
}