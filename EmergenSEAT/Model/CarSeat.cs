using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EmergenSEAT.Model
{
    public class CarSeat
    {
        #region Properties
        public string SerialNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public double Weight { get; private set; } = 0;
        public string WeightUnit { get; private set; } = "Lbs";
        public double Temperature { get; private set; } = 0;
        public string TemperatureUnit { get; private set; } = "Farenheit";
        public bool AlarmsEnabled { get; set; } = true;
        #endregion

        #region Public Methods
        /// <summary>
        /// Static Predicate indicating if given carseat is in alarm
        /// </summary>
        public static Predicate<CarSeat> InAlarm = (carSeat) => carSeat.Weight >= 5 && carSeat.Temperature >= 80;

        /// <summary>
        /// Set GPS location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public void SetGPSLocation(string latitude, string longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Set Weight
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="unit">Lbs is default</param>
        public void SetWeight(double weight, string unit = "Lbs")
        {
            this.Weight = weight;
            this.WeightUnit = unit;
        }

        /// <summary>
        /// Set Temperature
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="unit">Farenheit is defaul</param>
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
        #endregion
    }
}