using System;
using System.Collections.Generic;
using System.Text;

namespace EmergenSEAT.Model
{
    public class CarSeat
    {
        public string SerialNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public double Weight { get; private set; } = 0;
        public string WeightUnit { get; private set; } = "Lbs";
        public double Temperature { get; private set; } = 0;
        public string TemperatureUnit { get; private set; } = "Farenheit";

        public CarSeat(string serial_number, string make, string model)
        {
            //Vehicle vehicle = new Vehicle();
            this.SerialNumber = serial_number;
            this.Make = make;
            this.Model = model;
        }

        public void SetGPSLocation(string latitude, string longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public void SetWeight(double weight, string unit = "Lbs")
        {
            this.Weight = weight;
            this.WeightUnit = unit;
        }

        public void SetTemperature(double temp, string unit = "Farenheit")
        {
            this.Temperature = temp;
            this.TemperatureUnit = unit;
        }


        public void PrintCarSeat()
        {
            Console.WriteLine(SerialNumber);
            Console.WriteLine(Latitude);
            Console.WriteLine(Longitude);
        }


    }
}
