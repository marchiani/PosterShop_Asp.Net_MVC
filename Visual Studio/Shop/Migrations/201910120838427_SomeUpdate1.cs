namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Categoriesname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Categoriesname");
        }
    }
}
