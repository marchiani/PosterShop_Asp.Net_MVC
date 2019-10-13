namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderAddBascketAddCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.shopBaskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        TypeDelivery = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.shopBaskets", "ProductId", "dbo.Products");
            DropIndex("dbo.shopBaskets", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropColumn("dbo.Products", "Order_Id");
            DropTable("dbo.Orders");
            DropTable("dbo.shopBaskets");
        }
    }
}
