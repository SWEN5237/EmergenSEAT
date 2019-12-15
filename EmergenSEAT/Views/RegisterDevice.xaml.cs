using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmergenSEAT.Model;
using EmergenSEAT.ViewModel;
using Xamarin.Forms;

namespace EmergenSEAT.Views
{
    [DesignTimeVisible(false)]
    public partial class RegisterDevice : ContentPage
    {
        public EmergenSeatViewModel ViewModel { get; set; }
        public string SerialNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public RegisterDevice()
        {
            ViewModel = (EmergenSeatViewModel)Application.Current.BindingContext;
            this.BindingContext = this;
            InitializeComponent();
        }

        async void RegisterBtn_OnClick(object sender, EventArgs args)
        {
            CarSeat carSeat = new CarSeat() { SerialNumber = this.SerialNumber, Make = this.Make, Model = this.Model };
            var added = ViewModel.AddCarSeat(carSeat);
            if (added)
            {
                await (Navigation.PushAsync(new MainUserView()));
            }
            else
            {
                await DisplayAlert("Error", "Unable to Add Car Seat", "OK");
            }

        }

    }
}
