namespace web1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sections", "BookID");
            AddForeignKey("dbo.Sections", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "BookID", "dbo.Books");
            DropIndex("dbo.Sections", new[] { "BookID" });
            DropColumn("dbo.Sections", "BookID");
        }
    }
}
