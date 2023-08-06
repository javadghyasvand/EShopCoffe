using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{
    public class User_Details_MetaData
    {
        [Key]
        public long User_Detail_Id { get; set; }
        public long User_Id { get; set; }
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
    }
}