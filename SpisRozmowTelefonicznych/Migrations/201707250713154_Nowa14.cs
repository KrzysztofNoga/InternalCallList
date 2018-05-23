namespace SpisRozmowTelefonicznych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowa14 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Call", name: "ApplicationUser_Id", newName: "UserID");
            RenameColumn(table: "dbo.Phone", name: "ApplicationUser_Id", newName: "User_Id1");
            RenameIndex(table: "dbo.Call", name: "IX_ApplicationUser_Id", newName: "IX_UserID");
            RenameIndex(table: "dbo.Phone", name: "IX_ApplicationUser_Id", newName: "IX_User_Id1");
            AddColumn("dbo.Call", "dataDodania", c => c.DateTime(nullable: false));
            AddColumn("dbo.Phone", "User_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phone", "User_Id");
            DropColumn("dbo.Call", "dataDodania");
            RenameIndex(table: "dbo.Phone", name: "IX_User_Id1", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Call", name: "IX_UserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Phone", name: "User_Id1", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Call", name: "UserID", newName: "ApplicationUser_Id");
        }
    }
}
