using System;
using System.ComponentModel;
using EmergenSEAT.Views;
using Xamarin.Forms;

namespace EmergenSEAT
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public Button RegisterBtn { get; set; }
        public MainPage()
        {
            InitializeComponent();
            
        }
        async void RegisterBtn_OnClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RegisterUser());
        }
    }

}
