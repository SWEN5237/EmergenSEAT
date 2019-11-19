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
        public EmergenSeatViewModel ViewModel { get; private set; }
        public UserProfile ActiveUser { get; private set; }
        public CarSeat CarSeat { get; private set; }
        public string Weight { get; set; }

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

        public string WelcomeMessage { get; private set; }
        public ObservableCollection<CarSeat> CarSeats { get; set; }


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
                TempAndWeightAlert();
            }

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

            InitializeComponent();

        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            TempAndWeightAlert();
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

        private async void TempAndWeightAlert()
        { 
            CarSeat = ActiveUser.CarSeats[0];

            Weight = $"{ActiveUser.CarSeats[0].Weight} {ActiveUser.CarSeats[0].WeightUnit}";
            Temperature = $"{ActiveUser.CarSeats[0].Temperature} degrees {ActiveUser.CarSeats[0].TemperatureUnit}";


            if (CarSeat.Weight >= 5 && CarSeat.Temperature >= 78)
            {
                await DisplayAlert($"WARNING!", "Temperature is " + Temperature + " degrees\n" +
                                        "PLEASE CHECK BABY!", "Confirm");
            }

        }

    }
}
