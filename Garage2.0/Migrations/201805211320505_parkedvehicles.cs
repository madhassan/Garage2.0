namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkedvehicles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "Fule", c => c.String(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.String());
            DropColumn("dbo.ParkedVehicles", "Fule");
        }
    }
}
