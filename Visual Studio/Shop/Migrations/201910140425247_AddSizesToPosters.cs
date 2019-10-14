namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSizesToPosters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Size", c => c.String());
            AddColumn("dbo.shopBaskets", "Size", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.shopBaskets", "Size");
            DropColumn("dbo.Products", "Size");
        }
    }
}
