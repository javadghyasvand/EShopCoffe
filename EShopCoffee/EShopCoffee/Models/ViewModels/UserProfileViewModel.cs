using System;
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
        [DisplayName("کد پستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.PostalCode)]
        public string User_Postal_Code { get; set; }
        [DisplayName("استان")]
        public Nullable<int> User_State_ID { get; set; }
        [DisplayName("شهر")]
        public Nullable<int> User_City_ID { get; set; }

    }

}