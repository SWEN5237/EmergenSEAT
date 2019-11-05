using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace EmergenSEAT.Views
{
    [DesignTimeVisible(false)]
    public partial class RegisterDevice : ContentPage
    {
        public RegisterDevice()
        {
            InitializeComponent();
        }
        async void RegisterBtn_OnClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainUserView());
        }

    }
}
