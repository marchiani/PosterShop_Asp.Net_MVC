namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Size : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Size", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Size");
        }
    }
}
