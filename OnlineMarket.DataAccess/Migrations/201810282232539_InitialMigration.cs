namespace OnlineMarket.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CategoyId = c.Int(nullable: false),
                        QuantityInStock = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoyId, cascadeDelete: true)
                .Index(t => t.CategoyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoyId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoyId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
