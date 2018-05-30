using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public VehicleType type { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime TotalTime { get; set; }
        public double ParkingPrice { get; set; }

        public Receipt(ParkedVehicle p)
        {
            Id = p.Id;
            RegistrationNumber = p.RegistrationNumber;
            type = p.type;
            CheckIn = p.CheckInTime;
            CheckOut = p.CheckOutTime;
            TotalTime = p.TotalTime;
            ParkingPrice = p.ParkingPrice;
        }
    }
}