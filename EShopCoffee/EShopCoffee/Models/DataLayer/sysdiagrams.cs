
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
    
 [MetadataType(typeof(sysdiagrams_MetaData))]
    public partial class sysdiagrams
{

    public string name { get; set; }

    public int principal_id { get; set; }

    public int diagram_id { get; set; }

    public Nullable<int> version { get; set; }

    public byte[] definition { get; set; }

}

}