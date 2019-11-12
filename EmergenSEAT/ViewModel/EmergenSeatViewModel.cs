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
        public List<UserProfile> Profiles { get; set; }

        public EmergenSeatViewModel(UserProfile user)
        {
            Profiles = DataHandler.ImportFromJson(@"UserProfiles.json");
        }

        public event PropertyChangedEventHandler Propert yChanged;

        public bool Login(string username, string password)
        {
            
            if(ActiveUser.Email.Equals(username) && ActiveUser.Passw
        rd))
                return true;
            else
                return false;
        }
        
        public UserProfile Register(string username, string password, string firstName, string lastName)
        {
            ActiveUser = new UserProfile(username, firstName, lastName, password);
            Profiles.Add(ActiveUser);
            DataHandler.ExportToJson("", @"UserProfiles.json", Profiles);
            return Acti
             }

        public bo
            (CarSeat carSeat)
        {
            ActiveUser.AddCarSeat(carSeat);
            return true;
        }

        public bool DeleteCarSeat(string serialNumber)
        {  
            ActiveUser.DeleteCarSeat(serialNumb
               return true;
        }

        public List<CarSeat> GetCarSeats()
        {
            //TODO Get Carseats
            return ActiveUser.CarSeats; 
        }
    }
}