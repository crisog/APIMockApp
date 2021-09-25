using System;
using System.Collections.Generic;
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

        //public ICommand FetchCommand { get; }
        public IDictionary<string, double> Fuels = new Dictionary<string, double> {
            { "gasolinaPremium", 0},
            { "gasolinaRegular", 0 },
            { "gasoilOptimo", 0 },
            { "gasoilRegular", 0 },
            { "kerosene", 0 },
            { "gasLicuadoPetroleoGLP", 0 },
            { "gasNaturalVehicularGNV", 0 }
        };
        public FuelViewModel(IFuelApiService fuelApiService)
        {
            _fuelApiService = fuelApiService;
            //FetchCommand = new Command(OnFetch);
            LoadFuelsAsync();
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
                    Fuels["gasolinaPremium"] = Convert.ToDouble(fuels.GasolinaPremium);
                    Fuels["gasolinaRegular"] = Convert.ToDouble(fuels.GasolinaRegular);
                    Fuels["gasoilOptimo"] = Convert.ToDouble(fuels.GasoilOptimo);
                    Fuels["gasoilRegular"] = Convert.ToDouble(fuels.GasoilRegular);
                    Fuels["kerosene"] = Convert.ToDouble(fuels.Kerosene);
                    Fuels["gasLicuadoPetroleoGLP"] = Convert.ToDouble(fuels.GasLicuadoPetroleoGLP);
                    Fuels["gasNaturalVehicularGNV"] = Convert.ToDouble(fuels.GasNaturalVehicularGNV);
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
