//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShopCoffee.Models.DataLayer
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    
     [MetadataType(typeof(Users_MetaData))]
    public partial class Users
    {
        public long User_Id { get; set; }
        public long User_Role_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Phone { get; set; }
        public string User_Password { get; set; }
        public string User_Active_Code { get; set; }
        public bool User_IsActive { get; set; }
        public System.DateTime User_RegisterDate { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}