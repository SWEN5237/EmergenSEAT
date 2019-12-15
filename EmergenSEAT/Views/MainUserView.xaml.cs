using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using EmergenSEAT.Model;
using EmergenSEAT.ViewModel;
using Xamarin.Forms;

namespace EmergenSEAT.Views
{
    [DesignTimeVisible(false)]
    
    public partial class MainUserView : ContentPage, INotifyPropertyChanged
    {
        #region Properties
        public EmergenSeatViewModel ViewModel { get; private set; }
        public UserProfile ActiveUser { get; private set; }
        public string WelcomeMessage { get; private set; }

        private bool _AlarmsEnabled;
        public bool AlarmsEnabled {
            get { return _AlarmsEnabled; }
            set {
                _AlarmsEnabled = value;
                CarSeat.AlarmsEnabled = value;
            }
        }

        private CarSeat _CarSeat;
        public CarSeat CarSeat
        {
            get { return _CarSeat; }
            set
            {
                _CarSeat = value;
                OnPropertyChanged(nameof(CarSeat));
            }
        }

        private string _Weight;
        public string Weight
        {
            get { return _Weight; }
            set
            {
                _Weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private string _Temperature;
        public string Temperature
        {
            get { return _Temperature; }
            set
            {
                _Temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }
        #endregion

        public MainUserView()
        {
            //Set Binding Contexts
            ViewModel = (EmergenSeatViewModel)Application.Current.BindingContext;
            this.BindingContext = this;


            //Default 
            ActiveUser = ViewModel.ActiveUser;
            WelcomeMessage = string.Format("Welcome, {0}", ActiveUser.FirstName);

            if (ActiveUser != null && ActiveUser.CarSeats.Count > 0)
            {
                CarSeat = ActiveUser.CarSeats[0];
                Weight = $"{ActiveUser.CarSeats[0].Weight} {ActiveUser.CarSeats[0].WeightUnit}";
                Temperature = $"{ActiveUser.CarSeats[0].Temperature} degrees {ActiveUser.CarSeats[0].TemperatureUnit}";
                AlarmsEnabled = ActiveUser.CarSeats[0].AlarmsEnabled;
                TempAndWeightAlert();
            }

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            InitializeComponent();
        }

        #region Event Handlers
        //Update View When Model Property Changes
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Temperature") || e.PropertyName.Equals("Weight"))
            {
                Weight = $"{ActiveUser.CarSeats[0].Weight} {ActiveUser.CarSeats[0].WeightUnit}";
                Temperature = $"{ActiveUser.CarSeats[0].Temperature} degrees {ActiveUser.CarSeats[0].TemperatureUnit}";

                TempAndWeightAlert();
            }
        }

        async void RegisterBtn_OnClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RegisterDevice());
        }

        async void LogoutBtn_OnClick(object sender, EventArgs args)
        {
            ViewModel.ActiveUser = null;
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            await Navigation.PopToRootAsync();
        }
        #endregion

        //Display Alarm if CarSeat is in Alarm
        private void TempAndWeightAlert()
        {
            this.CarSeat = ActiveUser.CarSeats[0];

            if (this.CarSeat.AlarmsEnabled && CarSeat.InAlarm(this.CarSeat))
            {
                DisplayAlert($"WARNING!", "Temperature is " + Temperature + " degrees\n"
                    + "PLEASE CHECK BABY!", "Confirm");
            }
        }
    }
}
