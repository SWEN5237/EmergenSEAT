using System;
using System.Collections.Generic;

namespace EmergenSEAT.Model
{
    public class UserProfile
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<CarSeat> CarSeats { get; set; }

        public UserProfile(string email, string firstName, string lastName, string password)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            CarSeats = new List<CarSeat>();
        }

        public void AddCarSeat(CarSeat seat)
        {
            CarSeats.Add(seat);
        }
        public void DeleteCarSeat(string serialNumber)
        {
        }

        public void PrintUserProfile(CarSeat seats)
        {
            Console.WriteLine("Email: " + Email);
            foreach (CarSeat s in CarSeats)
            {
                seats.PrintCarSeat();
            }
        }
    }
}
