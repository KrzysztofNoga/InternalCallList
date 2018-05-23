namespace SpisRozmowTelefonicznych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowa12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Phone", "User_id_userData");
            DropColumn("dbo.Phone", "User_name");
            DropColumn("dbo.Phone", "User_lastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phone", "User_lastName", c => c.String());
            AddColumn("dbo.Phone", "User_name", c => c.String());
            AddColumn("dbo.Phone", "User_id_userData", c => c.Int(nullable: false));
        }
    }
}
