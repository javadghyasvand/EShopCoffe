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
    
     [MetadataType(typeof(Product_Select_Groups_MetaData))]
    public partial class Product_Select_Groups
    {
        public long Pro_Gro_Id { get; set; }
        public long Product_Id { get; set; }
        public long Group_Id { get; set; }
    
        public virtual Product_EShop Product_EShop { get; set; }
        public virtual Product_Groups Product_Groups { get; set; }
    }
}
