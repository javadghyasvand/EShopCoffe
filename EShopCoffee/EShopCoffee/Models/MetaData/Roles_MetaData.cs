using System.ComponentModel.DataAnnotations;

namespace EShopCoffee.Models
{
    public class Roles_MetaData
    {
        [Key]
        public long Role_Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Role_Title { get; set; }
    }
}