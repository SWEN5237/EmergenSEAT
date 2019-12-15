using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using EmergenSEAT.Model;
using Xamarin.Forms;

namespace EmergenSEAT.ViewModel
{
    public class EmergenSeatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public UserProfile ActiveUser { get; set; }
        public List<UserProfile> Profiles { get; set; }

        #region Public Methods
        /// <summary>
        /// Ctor
        /// </summary>
        public EmergenSeatViewModel()
        {
            Profiles = new List<UserProfile>();
            //Profiles = DataHandler.ImportFromJson(@"UserProfiles.json");
        }

        /// <summary>
        /// login with email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Register User Profile
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public UserProfile Register(string email, string password, string firstName, string lastName)
        {
            ActiveUser = new UserProfile() { Email = email, FirstName = firstName, LastName = lastName, Password = password };
            Profiles.Add(ActiveUser);
            //DataHandler.ExportToJson("", @"UserProfiles.json", Profiles);
            return ActiveUser;
        }

        /// <summary>
        /// Add CarSeat to active user
        /// </summary>
        /// <param name="carSeat"></param>
        /// <returns></returns>
        public bool AddCarSeat(CarSeat carSeat)
        {
            carSeat.SetWeight(5);
            carSeat.SetTemperature(70);
            bool added = ActiveUser.AddCarSeat(carSeat);

            if (added)
            {
                //Temporary dummy data until we integrate with hardware
                Device.StartTimer(TimeSpan.FromSeconds(15), () =>
                {
                    var temp = new Random().Next(60, 120);
                    carSeat.SetTemperature(temp);
                    OnPropertyChanged("Temperature");
                    return added;
                });
            }
            return added;
        }

        /// <summary>
        /// Delete CarSeat from Active User
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public bool DeleteCarSeat(string serialNumber)
        {
            return ActiveUser.DeleteCarSeat(serialNumber);
        }

        /// <summary>
        /// Get Active User Car Seats
        /// </summary>
        /// <returns></returns>
        public List<CarSeat> GetCarSeats()
        {
            return ActiveUser.CarSeats;
        }
        #endregion

        #region Events
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (ActiveUser != null)
            {
                Debug.WriteLine($"{propertyName} changed to {ActiveUser.CarSeats[0].Temperature}");
                var propertyChangedCallback = PropertyChanged;
                propertyChangedCallback?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
