using System;
using System.Collections.Generic;
using System.Windows.Input;
using APIMockApp.Services;
using Xamarin.Forms;

namespace APIMockApp.ViewModels
{
    public class FuelViewModel: BaseViewModel
    {

        public ICommand FetchCommand { get; }
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
            FetchCommand = new Command(OnFetch);
        }

        private async void OnFetch(object obj)
        {
            var fuelsResponse = await _fuelApiService.GetFuelsAsync();
            if(fuelsResponse != null)
            {
                return;
            }
        }

        IFuelApiService _fuelApiService;
    }
}
