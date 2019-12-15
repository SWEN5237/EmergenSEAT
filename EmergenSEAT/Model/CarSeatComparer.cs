using System.Collections.Generic;

namespace EmergenSEAT.Model
{
    public class CarSeatComparer : IEqualityComparer<CarSeat>
    {
        public bool Equals(CarSeat carSeatA, CarSeat carSeatB)
        {
            return carSeatA.SerialNumber.Equals(carSeatB.SerialNumber);
        }

        public int GetHashCode(CarSeat carSeat)
        {
            return carSeat.GetHashCode();
        }
    }
}
