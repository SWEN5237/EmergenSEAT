using System;
using System.Collections.Generic;
using System.Linq;

namespace EmergenSEAT.Model
{
    public class UserProfile
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<CarSeat> CarSeats { get; private set; }
        private IEqualityComparer<CarSeat> carSeatComparer;

        public UserProfile()
        {
            this.CarSeats = new List<CarSeat>();
            carSeatComparer = new CarSeatComparer();
        }

        /// <summary>
        /// Adds Unique CarSeat to Profile
        /// </summary>
        /// <param name="seat"></param>
        /// <returns>bool indicating addition was successful</returns>
        public bool AddCarSeat(CarSeat seat)
        {
            if (!this.CarSeats.Contains(seat, carSeatComparer)){
                this.CarSeats.Add(seat);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes CarSeat given a serial number
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns>indicates if deletion was successful</returns>
        public bool DeleteCarSeat(string serialNumber)
        {
            var carSeat = this.CarSeats.Find((cs) => cs.SerialNumber.Equals(serialNumber));
            if(carSeat != null)
            {
                CarSeats.Remove(carSeat);
                return true;
            }
            return false;
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
