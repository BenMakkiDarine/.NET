namespace GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstPush : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.aspnetroles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.aspnetuserroles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.aspnetroles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.aspnetusers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.aspnetusers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 128, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.aspnetuserclaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.aspnetusers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.aspnetuserlogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.aspnetusers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.aspnetuserroles", "UserId", "dbo.aspnetusers");
            DropForeignKey("dbo.aspnetuserlogins", "UserId", "dbo.aspnetusers");
            DropForeignKey("dbo.aspnetuserclaims", "UserId", "dbo.aspnetusers");
            DropForeignKey("dbo.aspnetuserroles", "RoleId", "dbo.aspnetroles");
            DropIndex("dbo.aspnetuserlogins", new[] { "UserId" });
            DropIndex("dbo.aspnetuserclaims", new[] { "UserId" });
            DropIndex("dbo.aspnetusers", "UserNameIndex");
            DropIndex("dbo.aspnetuserroles", new[] { "RoleId" });
            DropIndex("dbo.aspnetuserroles", new[] { "UserId" });
            DropIndex("dbo.aspnetroles", "RoleNameIndex");
            DropTable("dbo.aspnetuserlogins");
            DropTable("dbo.aspnetuserclaims");
            DropTable("dbo.aspnetusers");
            DropTable("dbo.aspnetuserroles");
            DropTable("dbo.aspnetroles");
        }
    }
}
