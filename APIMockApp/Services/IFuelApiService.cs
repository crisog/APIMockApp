using System;
using System.Threading.Tasks;
using APIMockApp.Models;

namespace APIMockApp.Services
{
    public interface IFuelApiService
    {
        Task<FuelResponse> GetFuels();
    }
}
