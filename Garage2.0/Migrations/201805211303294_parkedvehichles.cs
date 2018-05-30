namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkedvehichles : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "IsParked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "IsParked", c => c.Boolean(nullable: false));
        }
    }
}
