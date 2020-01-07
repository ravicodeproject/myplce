namespace web1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookImages",
                c => new
                    {
                        BookImageID = c.Int(nullable: false, identity: true),
                        BookSocialMedia = c.String(unicode: false),
                        BookMetaImage = c.String(unicode: false),
                        BookMetaImageWidth = c.String(unicode: false),
                        BookMetaImageHeight = c.String(unicode: false),
                        BookImageCreatedTime = c.DateTime(nullable: false, precision: 0),
                        BookImageUpdatedTime = c.DateTime(nullable: false, precision: 0),
                        BookID = c.Int(nullable: false),
                        Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.BookImageID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.BookID)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(unicode: false),
                        BookContent = c.String(unicode: false),
                        BookMetaDescription = c.String(unicode: false),
                        BookMetaKeywords = c.String(unicode: false),
                        BookMetaAuthor = c.String(unicode: false),
                        BookCreatedTime = c.DateTime(nullable: false, precision: 0),
                        BookUpdatedTime = c.DateTime(nullable: false, precision: 0),
                        Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserID = c.Int(nullable: false, identity: true),
                        Fname = c.String(unicode: false),
                        Lname = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(unicode: false),
                        DOB = c.DateTime(nullable: false, precision: 0),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                        UpdatedTime = c.DateTime(nullable: false, precision: 0),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SectionImages",
                c => new
                    {
                        SectionImageID = c.Int(nullable: false, identity: true),
                        SectionSocialMedia = c.String(unicode: false),
                        SectionMetaImage = c.String(unicode: false),
                        SectionMetaImageWidth = c.String(unicode: false),
                        SectionMetaImageHeight = c.String(unicode: false),
                        SectionImageCreatedTime = c.DateTime(nullable: false, precision: 0),
                        SectionImageUpdatedTime = c.DateTime(nullable: false, precision: 0),
                        SectionID = c.Int(nullable: false),
                        Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.SectionImageID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.SectionID)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        SectionTitle = c.String(unicode: false),
                        SectionContent = c.String(unicode: false),
                        SectionMetaDescription = c.String(unicode: false),
                        SectionMetaKeywords = c.String(unicode: false),
                        SectionMetaAuthor = c.String(unicode: false),
                        SectionCreatedTime = c.DateTime(nullable: false, precision: 0),
                        SectionUpdatedTime = c.DateTime(nullable: false, precision: 0),
                        Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.SectionID)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.SectionImages", "Id", "dbo.Users");
            DropForeignKey("dbo.Sections", "Id", "dbo.Users");
            DropForeignKey("dbo.SectionImages", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Books", "Id", "dbo.Users");
            DropForeignKey("dbo.BookImages", "Id", "dbo.Users");
            DropForeignKey("dbo.BookImages", "BookID", "dbo.Books");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Sections", new[] { "Id" });
            DropIndex("dbo.SectionImages", new[] { "Id" });
            DropIndex("dbo.SectionImages", new[] { "SectionID" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Books", new[] { "Id" });
            DropIndex("dbo.BookImages", new[] { "Id" });
            DropIndex("dbo.BookImages", new[] { "BookID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Sections");
            DropTable("dbo.SectionImages");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Books");
            DropTable("dbo.BookImages");
        }
    }
}
