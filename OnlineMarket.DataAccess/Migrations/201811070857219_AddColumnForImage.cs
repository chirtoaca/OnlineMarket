namespace OnlineMarket.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnForImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageData", c => c.Binary());
            AddColumn("dbo.Products", "ImageMimeTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageMimeTime");
            DropColumn("dbo.Products", "ImageData");
        }
    }
}
