using EShopCoffee.Models.DataLayer;
using System;
using System.Linq;
using System.Web.Security;

namespace MyShop.Utilities
{
    public class ShopRoleProvider : RoleProvider
    {
        private readonly EShopCoffe_DBEntities _cms = new EShopCoffe_DBEntities();

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (EShopCoffe_DBEntities dbEntities = new EShopCoffe_DBEntities())
            {
                var result = dbEntities.Users.Where(u => u.User_Email == username).Select(u => u.Roles.Role_Id).ToArray();

                string[] resultstr = result.Select(i => i.ToString()).ToArray();

                return resultstr;

            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}