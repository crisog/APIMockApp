﻿using System;
using System.Collections.Generic;
using APIMockApp.ViewModels;
using Xamarin.Forms;

namespace APIMockApp.Views
{
    public partial class FuelPage : ContentPage
    {
        public FuelPage()
        {
            InitializeComponent();
            BindingContext = new FuelViewModel();
        }
    }
}
