namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelProductShop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        srcImg = c.String(),
                        heading = c.String(),
                        Price = c.Int(nullable: false),
                        CategoriesId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoriesId)
                .Index(t => t.CategoriesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoriesId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoriesId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
