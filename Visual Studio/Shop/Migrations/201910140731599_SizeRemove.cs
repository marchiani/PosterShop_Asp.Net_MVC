namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SizeRemove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Size", c => c.String());
        }
    }
}
