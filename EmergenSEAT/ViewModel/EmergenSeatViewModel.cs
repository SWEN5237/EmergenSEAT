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

        public EmergenSeatViewModel()
        {
            Profiles = new List<UserProfile>();
            //Profiles = DataHandler.ImportFromJson(@"UserProfiles.json");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Login(string email, string password)
        {
            var userProfile = Profiles.Find((profile) => profile.Email == email);
            if (userProfile != null)
            {
                if (userProfile.Email.Equals(email) && userProfile.Password.Equals(password))
                {
                    ActiveUser = userProfile;
                    return true;
                }
            }
            return false;
        }

        public UserProfile Register(string username, string password, string firstName, string lastName)
        {
            ActiveUser = new UserProfile(username, firstName, lastName, password);
            Profiles.Add(ActiveUser);
            //DataHandler.ExportToJson("", @"UserProfiles.json", Profiles);
            return ActiveUser;
        }

        public bool AddCarSeat(CarSeat carSeat)
        {
            ActiveUser.AddCarSeat(carSeat);
            return true;
        }

        public bool DeleteCarSeat(string serialNumber)
        {
            ActiveUser.DeleteCarSeat(serialNumber);
            return true;
        }

        public List<CarSeat> GetCarSeats()
        {
            //TODO Get Carseats
            return ActiveUser.CarSeats;
        }
    }
}
