namespace SpisRozmowTelefonicznych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowa6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Call", "User_id_UD", "dbo.UserData");
            DropForeignKey("dbo.Phone", "id_user", "dbo.UserData");
            DropIndex("dbo.Call", new[] { "User_id_UD" });
            DropIndex("dbo.Phone", new[] { "id_user" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserData_id_userData = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Call", "User_id_userData", c => c.Int(nullable: false));
            AddColumn("dbo.Call", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Phone", "User_id_userData", c => c.Int(nullable: false));
            AddColumn("dbo.Phone", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Call", "ApplicationUser_Id");
            CreateIndex("dbo.Phone", "ApplicationUser_Id");
            AddForeignKey("dbo.Call", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Phone", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Call", "User_id_UD");
            DropColumn("dbo.Phone", "id_user");
            DropTable("dbo.UserData");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserData",
                c => new
                    {
                        id_UD = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.id_UD);
            
            AddColumn("dbo.Phone", "id_user", c => c.Int(nullable: false));
            AddColumn("dbo.Call", "User_id_UD", c => c.Int());
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Phone", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Call", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Phone", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Call", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Phone", "ApplicationUser_Id");
            DropColumn("dbo.Phone", "User_id_userData");
            DropColumn("dbo.Call", "ApplicationUser_Id");
            DropColumn("dbo.Call", "User_id_userData");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.Phone", "id_user");
            CreateIndex("dbo.Call", "User_id_UD");
            AddForeignKey("dbo.Phone", "id_user", "dbo.UserData", "id_UD", cascadeDelete: true);
            AddForeignKey("dbo.Call", "User_id_UD", "dbo.UserData", "id_UD");
        }
    }
}
