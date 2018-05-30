namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2._0.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._0.DataAccessLayer.StorageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2._0.DataAccessLayer.StorageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ParkedVehicle parkedVehicle = new ParkedVehicle() {RegistrationNumber="cxv-231",type = VehicleType.Airplane, Brand="BMW", Color="Black", Model="Sports", NoOfWheels= 4,CheckInTime = DateTime.Now };

            context.parkedVehicles.AddOrUpdate(v => v.RegistrationNumber);
        }
    }
}
