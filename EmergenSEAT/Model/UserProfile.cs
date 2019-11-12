using System;
using System.Collections.Generic;
using System.Text;

namespace EmergenSEAT.Model
{
    public class UserProfile
    {
        public string email;
        public string first_name;
        public string last_name;
        public string password;
        public List<CarSeat> car_seats;

        public UserProfile(string email, string first_name, string last_name, string password)
        {
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
            this.password = password;
            car_seats = new List<CarSeat>();
        }

        public void AddCarSeat(CarSeat seat)
        {
            car_seats.Add(seat);
        }
        public void DeleteCarSeat(CarSeat seat)
        {
            //check of car_seats contains a certain serial
            foreach (CarSeat seats in car_seats)
            {
                if (seats.serial_number.Equals(seat.serial_number))
                    car_seats.Remove(seat);
            }

        }

        public void PrintUserProfile(CarSeat seats)
        {
            Console.WriteLine("Email: " + email);
            foreach (CarSeat s in car_seats)
            {
                seats.PrintCarSeat();
            }
        }


    }
}
