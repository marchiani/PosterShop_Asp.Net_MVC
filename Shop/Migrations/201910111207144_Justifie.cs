namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Justifie : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.shopBaskets", "ProductId");
            AddForeignKey("dbo.shopBaskets", "ProductId", "dbo.Products", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.shopBaskets", "ProductId", "dbo.Products");
            DropIndex("dbo.shopBaskets", new[] { "ProductId" });
        }
    }
}
