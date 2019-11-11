using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmergenSEAT.ViewModel;
using Xamarin.Forms;

namespace EmergenSEAT.Views
{
    [DesignTimeVisible(false)]
    public partial class RegisterUser : ContentPage
    {
        public EmergenSeatViewModel ViewModel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUser()
        {
            ViewModel = (EmergenSeatViewModel)Application.Current.BindingContext;
            this.BindingContext = this;
            InitializeComponent();
        }

        async void RegisterBtn_OnClick(object sender, EventArgs args)
        {
            if (Email != null && Password != null)
            {
                var newUserProfile = ViewModel.Register(Email, Password);
                if (newUserProfile != null)
                {
                    await Navigation.PushAsync(new MainUserView());
                }
            }
            else
            {
                await DisplayAlert("Missing Required Fields", "Email/Password Fields are reqired", "OK");
            }
        }
    }
}
