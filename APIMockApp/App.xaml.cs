using System;
using APIMockApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIMockApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FuelPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
