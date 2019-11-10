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

        public EmergenSeatViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Login(string username, string password)
        {
            //TODO do actual login
            return true;
        }
        
        public UserProfile Register(string username, string password)
        {
            //TODO register
            return new UserProfile(username, "", "", password);
        }

        public bool AddCarSeat(CarSeat carSeat)
        {
            //TODO add carseat to active user
            return true;
        }

        public bool DeleteCarSeat(string serialNumber)
        {  
            //TODO delete carseat
            return true;
        }

        public List<CarSeat> GetCarSeats()
        {
            //TODO Get Carseats
            return new List<CarSeat>();
        }
    }
}
