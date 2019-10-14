namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeinerKeyBasket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.shopBaskets", "ProductId", "dbo.Products");
            DropIndex("dbo.shopBaskets", new[] { "ProductId" });
            AddColumn("dbo.Products", "ShopBasketId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ShopBasketId");
            CreateIndex("dbo.shopBaskets", "ProductId");
            AddForeignKey("dbo.shopBaskets", "ProductId", "dbo.Products", "id", cascadeDelete: true);
        }
    }
}
