namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginAndRegister : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Name", c => c.String());
        }
    }
}
