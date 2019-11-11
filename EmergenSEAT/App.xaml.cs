using System;
using EmergenSEAT.ViewModel;
using EmergenSEAT.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergenSEAT
{
    public partial class App : Application
    {
        public EmergenSeatViewModel ESViewModel { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            BindingContext = ESViewModel = new EmergenSeatViewModel();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
