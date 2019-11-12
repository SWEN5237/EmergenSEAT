using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using EmergenSEAT.Model;
using EmergenSEAT.ViewModel;
using Xamarin.Forms;

namespace EmergenSEAT.Views
{
    [DesignTimeVisible(false)]
    public partial class MainUserView : ContentPage
    {
        public EmergenSeatViewModel ViewModel { get; set; }
        public UserProfile ActiveUser { get; set; } 
        public string WelcomeMessage { get; set; }
        public ObservableCollection<CarSeat> CarSeats { get; set; }


        public MainUserView()
        {
            //Set Binding Contexts
            ViewModel = (EmergenSeatViewModel)Application.Current.BindingContext;
            this.BindingContext = this;

            //Default 
            ActiveUser = ViewModel.ActiveUser;
            WelcomeMessage = string.Format("Welcome, {0}", ActiveUser.FirstName);

            int numCarSeats = ActiveUser.CarSeats.Count;
            Enumerable.Range(1, numCarSeats).ToList().ForEach((x) => CarSeatGrid.RowDefinitions.Add(new RowDefinition()));
            int i = 0;
            ActiveUser.CarSeats.ForEach((carSeat)=> {
                var carSeatData = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n", carSeat.SerialNumber, carSeat.Model, carSeat.Temperature, carSeat.Latitude, carSeat.Longitude);
                var label = new Label
                {
                    Text = carSeatData,
                    HorizontalOptions = LayoutOptions.Center
                };
                CarSeatGrid.Children.Add(label, 0, i);
                i++;
            });

            InitializeComponent();
        }

        async void RegisterBtn_OnClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RegisterDevice());
        }

        async void LogoutBtn_OnClick(object sender, EventArgs args)
        {
            ViewModel.ActiveUser = null;
            await Navigation.PopToRootAsync();
        }


    }
}
