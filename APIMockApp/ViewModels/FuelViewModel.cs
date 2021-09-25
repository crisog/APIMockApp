﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using APIMockApp.Models;
using APIMockApp.Services;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace APIMockApp.ViewModels
{
    public class FuelViewModel: BaseViewModel
    {
        //public ICommand LoadCommand { get; }
        public ObservableCollection<Fuel> Fuels { get; set; } = new ObservableCollection<Fuel>() { };
        public FuelViewModel(IFuelApiService fuelApiService)
        {
            _fuelApiService = fuelApiService;
            //LoadCommand = new Command(OnLoad);
            //LoadFuelsAsync();
            Fuels.Add(new Fuel() { Name = "Default", Price = 0 });
        }

        private async void OnLoad()
        {
            await LoadFuelsAsync();
        }

        public async Task LoadFuelsAsync()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await _fuelApiService.GetFuelsAsync();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var fuels = JsonSerializer.Deserialize<FuelResponse>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    // Save Fuels
                    Fuels.Add(new Fuel()
                    {
                        Name = "GasolinaPremium",
                        Price = Convert.ToDouble(fuels.GasolinaPremium)
                    });
                    Fuels.Add(new Fuel()
                    {
                        Name = "GasolinaRegular",
                        Price = Convert.ToDouble(fuels.GasolinaRegular)
                    });
                    Fuels.Add(new Fuel()
                    {
                        Name = "GasoilOptimo",
                        Price = Convert.ToDouble(fuels.GasoilOptimo)
                    });
                    Fuels.Add(new Fuel()
                    {
                        Name = "GasoilRegular",
                        Price = Convert.ToDouble(fuels.GasoilRegular)
                    });
                    Fuels.Add(new Fuel()
                    {
                        Name = "Kerosene",
                        Price = Convert.ToDouble(fuels.Kerosene)
                    });
                    Fuels.Add(new Fuel()
                    {
                        Name = "GasLicuadoPetroleoGLP",
                        Price = Convert.ToDouble(fuels.GasLicuadoPetroleoGLP)
                    });
                    Fuels.Add(new Fuel()
                    {
                        Name = "GasNaturalVehicularGNV",
                        Price = Convert.ToDouble(fuels.GasNaturalVehicularGNV)
                    });
                    Console.WriteLine("Hello");
                }
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "No hay conexión a internet.", "OK");
                });
            }
        }

        IFuelApiService _fuelApiService;
    }
}
