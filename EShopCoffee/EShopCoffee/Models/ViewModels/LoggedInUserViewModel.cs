namespace EShopCoffee.Models.ViewModels
{
    public class LoggedInUserViewModel
    {
        public long User_Id { get; set; }
        public long User_Role_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Image { get; set; }
    }
}