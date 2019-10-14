namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Justifie1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ShopBasketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ShopBasketId", c => c.Int());
        }
    }
}
