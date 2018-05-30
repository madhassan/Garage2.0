namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "Fule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "Fule", c => c.String(nullable: false));
        }
    }
}
