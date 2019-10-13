using Shop.Models.ShopModel;

namespace Shop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categorieses { get; set; }

        public DbSet<shopBasket> ShopBaskets { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
