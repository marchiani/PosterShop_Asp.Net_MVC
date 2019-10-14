namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "CategoriesId", newName: "Categories_id");
            RenameIndex(table: "dbo.Products", name: "IX_CategoriesId", newName: "IX_Categories_id");
            AlterColumn("dbo.Products", "srcImg", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "heading", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Categoriesname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Categoriesname", c => c.String());
            AlterColumn("dbo.Products", "heading", c => c.String());
            AlterColumn("dbo.Products", "srcImg", c => c.String());
            RenameIndex(table: "dbo.Products", name: "IX_Categories_id", newName: "IX_CategoriesId");
            RenameColumn(table: "dbo.Products", name: "Categories_id", newName: "CategoriesId");
        }
    }
}
