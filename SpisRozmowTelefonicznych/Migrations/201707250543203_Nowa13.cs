namespace SpisRozmowTelefonicznych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowa13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Call", "User_id_userData");
            DropColumn("dbo.Call", "User_name");
            DropColumn("dbo.Call", "User_lastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Call", "User_lastName", c => c.String());
            AddColumn("dbo.Call", "User_name", c => c.String());
            AddColumn("dbo.Call", "User_id_userData", c => c.Int(nullable: false));
        }
    }
}
