using System;
using System.Collections.Generic;
using APIMockApp.ViewModels;
using Xamarin.Forms;

namespace APIMockApp.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }
    }
}

