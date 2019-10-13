namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToOrderStringOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            AddColumn("dbo.Orders", "PostersThatOrser", c => c.String());
            AddColumn("dbo.Orders", "DataSet", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            DropColumn("dbo.Orders", "DataSet");
            DropColumn("dbo.Orders", "PostersThatOrser");
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
