﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShopCoffee.Models.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EShopCoffe_DBEntities : DbContext
    {
        public EShopCoffe_DBEntities()
            : base("name=EShopCoffe_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product_Comments> Product_Comments { get; set; }
        public virtual DbSet<Product_EShop> Product_EShop { get; set; }
        public virtual DbSet<Product_Galllery> Product_Galllery { get; set; }
        public virtual DbSet<Product_Groups> Product_Groups { get; set; }
        public virtual DbSet<Product_Proerty_Select> Product_Proerty_Select { get; set; }
        public virtual DbSet<Product_Property> Product_Property { get; set; }
        public virtual DbSet<Product_Select_Groups> Product_Select_Groups { get; set; }
        public virtual DbSet<Product_Tags> Product_Tags { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<tblOstan> tblOstan { get; set; }
        public virtual DbSet<tblShahrestan> tblShahrestan { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<TotalSell> TotalSell { get; set; }
        public virtual DbSet<PersntOff> PersntOff { get; set; }
        public virtual DbSet<ShopCard> ShopCard { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
