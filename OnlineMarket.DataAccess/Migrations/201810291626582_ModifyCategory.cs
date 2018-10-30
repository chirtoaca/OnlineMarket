namespace OnlineMarket.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "CategoyId", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_CategoyId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_CategoyId");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "CategoyId");
        }
    }
}
