using System;
using System.ComponentModel;
using EmergenSEAT.ViewModel;
using EmergenSEAT.Views;
using Xamarin.Forms;

namespace EmergenSEAT
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public EmergenSeatViewModel ViewModel { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        async void LoginBtn_OnClick(object sender, EventArgs args)
        {
            if (ViewModel == null) { ViewModel = (EmergenSeatViewModel)Application.Current.BindingContext; }

            if (Email != null && Password != null)
            {
                if (ViewModel.Login(Email, Password))
                {
                    await Navigation.PushAsync(new MainUserView());
                }
                else
                {
                    await DisplayAlert("Login Failed", "Invalid Email/Password Combination", "OK");
                }
            }
        }

        async void RegisterBtn_OnClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RegisterUser());
        }
    }

}
