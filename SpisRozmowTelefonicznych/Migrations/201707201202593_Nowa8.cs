namespace SpisRozmowTelefonicznych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowa8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Call", "User_name", c => c.String());
            AddColumn("dbo.Phone", "User_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_name", c => c.String());
            DropColumn("dbo.Call", "User_nameX");
            DropColumn("dbo.Phone", "User_nameX");
            DropColumn("dbo.AspNetUsers", "UserData_nameX");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserData_nameX", c => c.String());
            AddColumn("dbo.Phone", "User_nameX", c => c.String());
            AddColumn("dbo.Call", "User_nameX", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_name");
            DropColumn("dbo.Phone", "User_name");
            DropColumn("dbo.Call", "User_name");
        }
    }
}
