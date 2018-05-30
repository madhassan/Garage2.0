using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(7,ErrorMessage ="Too long for registration number")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public VehicleType type { get; set; }

        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Characters only")]
        public string Color { get; set; }

        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Characters only")]
        public string Brand { get; set; }

        public string Model { get; set; }

        [Display(Name = "No of Wheels")]
        public int NoOfWheels { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CheckInTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CheckOutTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TotalTime { get; set; }
        public double ParkingPrice { get; set; }

        public ParkedVehicle()
        {
            CheckInTime = DateTime.Now;
            CheckOutTime = DateTime.Now;
            TotalTime = DateTime.Now;
        }
    }

    public enum VehicleType
    {
        Airplane,
        Boat,
        Bus,
        Car,
        Cycle,
        Motorcycle,
        Train,
        Truck
    }
}