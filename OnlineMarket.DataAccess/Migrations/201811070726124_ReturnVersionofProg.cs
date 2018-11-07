namespace OnlineMarket.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnVersionofProg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ImageData");
            DropColumn("dbo.Products", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageMimeType", c => c.String());
            AddColumn("dbo.Products", "ImageData", c => c.Binary());
        }
    }
}
