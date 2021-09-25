using System;
using System.Net.Http;
using System.Threading.Tasks;
using APIMockApp.Models;
using Refit;

namespace APIMockApp.Services
{
    public class FuelApiService: IFuelApiService
    {
        public async Task<HttpResponseMessage> GetFuelsAsync()
        {
            return await RestService.For<IFuelApi>("http://eladio37-001-site1.ftempurl.com").GetFuelsAsync();
        }
    }
}
