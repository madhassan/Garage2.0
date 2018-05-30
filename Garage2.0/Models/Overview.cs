using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class Overview
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleType vehicletype { get; set; }


        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

       
        public string Color { get; set; }
        public DateTime ParkingTime { get; set; }
        public DateTime CheckoutTime { get; set; }

        public Overview(ParkedVehicle parked)
        {
            Id = parked.Id;
            vehicletype = parked.type;
            RegistrationNumber = parked.RegistrationNumber;
            Color = parked.Color;
            ParkingTime = parked.CheckInTime;
            CheckoutTime = parked.CheckOutTime;
        }
    }
}