using System;
using System.Collections.Generic;
using System.Text;

namespace EmergenSEAT.Model
{
    public class Car
    {
        public string make;
        public string model;
        public string year;
        public string vin;

        public Car(string make, string model, string year, string vin)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.vin = vin;
        }

        public void update_car_details(string make, string model, string year, string vin)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.vin = vin;
        }
    }
}
