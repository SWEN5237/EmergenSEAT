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
        public CarSeat CarSeat { get; set; }
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

            if(ActiveUser != null && ActiveUser.CarSeats.Count > 0) { CarSeat = ActiveUser.CarSeats[0]; }

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
