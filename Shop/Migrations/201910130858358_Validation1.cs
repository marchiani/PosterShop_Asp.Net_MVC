namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Name", c => c.String());
        }
    }
}
