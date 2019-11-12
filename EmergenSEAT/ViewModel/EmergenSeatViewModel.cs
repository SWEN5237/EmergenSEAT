using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using EmergenSEAT.Model;

namespace EmergenSEAT.ViewModel
{
    public class EmergenSeatViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }
        public UserProfile ActiveUser { get; set; }

        public EmergenSeatViewModel(UserProfile user)
        {
            ActiveUser = user;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Login(string username, string password)
        {
            //TODO do actual login
            if(ActiveUser.email.equals(username) && ActiveUser.password.equals(password))
                return true;
            else
                return false;
        }
        
        public UserProfile Register(string username, string password)
        {
            //TODO register
            return new UserProfile(username, "", "", password);
        }

        public bool AddCarSeat(CarSeat carSeat)
        {
            //TODO add carseat to active user
            ActiveUser.AddCarSeat(carSeat.serial_number);
            return true;
        }

        public bool DeleteCarSeat(CarSeat carSeat)
        {  
            //TODO delete carseat
            ActiveUser.DeleteCarSeat(carSeat.serial_number);
            return true;
        }

        public List<CarSeat> GetCarSeats(CarSeat carSeat)
        {
            //TODO Get Carseats
            return carSeat.car_seats; 
        }
    }
}
