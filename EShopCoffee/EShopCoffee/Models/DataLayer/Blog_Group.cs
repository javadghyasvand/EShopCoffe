
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
    
 [MetadataType(typeof(Blog_Group_MetaData))]
    public partial class Blog_Group
{

    public int GroupId { get; set; }

    public string GroupName { get; set; }

    public string GroupShortDescription { get; set; }

    public bool IsDeleted { get; set; }



    public virtual Blog_Post Blog_Post { get; set; }

}

}