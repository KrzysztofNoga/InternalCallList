namespace SpisRozmowTelefonicznych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Call",
                c => new
                    {
                        id_call = c.Int(nullable: false, identity: true),
                        id_phone = c.Int(nullable: false),
                        caller_number = c.String(),
                        date = c.DateTime(nullable: false),
                        adresseID = c.String(),
                        callerName = c.String(),
                        callerLastName = c.String(),
                        description = c.String(),
                        status = c.Boolean(nullable: false),
                        User_id_UD = c.Int(),
                    })
                .PrimaryKey(t => t.id_call)
                .ForeignKey("dbo.UserData", t => t.User_id_UD)
                .ForeignKey("dbo.Phone", t => t.id_phone, cascadeDelete: true)
                .Index(t => t.id_phone)
                .Index(t => t.User_id_UD);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        id_phone = c.Int(nullable: false, identity: true),
                        id_user = c.Int(nullable: false),
                        phone_number = c.String(),
                        room_number = c.String(),
                    })
                .PrimaryKey(t => t.id_phone)
                .ForeignKey("dbo.UserData", t => t.id_user, cascadeDelete: true)
                .Index(t => t.id_user);
            
            CreateTable(
                "dbo.UserData",
                c => new
                    {
                        id_UD = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.id_UD);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Call", "id_phone", "dbo.Phone");
            DropForeignKey("dbo.Phone", "id_user", "dbo.UserData");
            DropForeignKey("dbo.Call", "User_id_UD", "dbo.UserData");
            DropIndex("dbo.Phone", new[] { "id_user" });
            DropIndex("dbo.Call", new[] { "User_id_UD" });
            DropIndex("dbo.Call", new[] { "id_phone" });
            DropTable("dbo.UserData");
            DropTable("dbo.Phone");
            DropTable("dbo.Call");
        }
    }
}
