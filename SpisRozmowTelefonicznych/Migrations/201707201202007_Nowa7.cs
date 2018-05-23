namespace SpisRozmowTelefonicznych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowa7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Call", "User_nameX", c => c.String());
            AddColumn("dbo.Call", "User_lastName", c => c.String());
            AddColumn("dbo.Phone", "User_nameX", c => c.String());
            AddColumn("dbo.Phone", "User_lastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_nameX", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_lastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserData_lastName");
            DropColumn("dbo.AspNetUsers", "UserData_nameX");
            DropColumn("dbo.Phone", "User_lastName");
            DropColumn("dbo.Phone", "User_nameX");
            DropColumn("dbo.Call", "User_lastName");
            DropColumn("dbo.Call", "User_nameX");
        }
    }
}
