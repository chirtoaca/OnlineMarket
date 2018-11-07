namespace OnlineMarket.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageData", c => c.Binary());
            AddColumn("dbo.Products", "ImageMimeType", c => c.String());
            DropColumn("dbo.Products", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
            DropColumn("dbo.Products", "ImageMimeType");
            DropColumn("dbo.Products", "ImageData");
        }
    }
}
