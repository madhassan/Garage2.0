namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isparked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "IsParked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "IsParked");
        }
    }
}
