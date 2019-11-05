using System;
using System.Collections.Generic;
using System.Text;

namespace EmergenSEAT.Model
{
    public class CarSeat
    {
        public string serial_number;
        public string model;
        public string latitude;
        public string longitude;
        public double weight = 0;
        public string weight_unit = "Lbs";
        public double temperature = 0;
        public string temperature_unit = "Farenheit";

        public CarSeat(string serial_number, string model, string latitude, string longitude, double weight, double temperature)
        {
            //Vehicle vehicle = new Vehicle();
            this.serial_number = serial_number;
            this.model = model;
            this.latitude = latitude;
            this.longitude = longitude;
            this.weight = weight;
            this.temperature = temperature;

        }

        public void set_gps_location(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public void set_weight(double weight, string unit)
        {
            this.weight = weight;
            weight_unit = unit;
        }

        public void set_temperature(double temp, string unit)
        {
            temperature = temp;
            temperature_unit = unit;
        }


        public void print_car_seat()
        {
            Console.WriteLine(serial_number);
            Console.WriteLine(latitude);
            Console.WriteLine(longitude);
        }


    }
}
