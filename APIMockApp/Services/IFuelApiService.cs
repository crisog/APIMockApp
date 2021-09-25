using System;
using System.Net.Http;
using System.Threading.Tasks;
using APIMockApp.Models;
using Refit;

namespace APIMockApp.Services
{
    public interface IFuelApiService
    {
        
        Task<HttpResponseMessage> GetFuelsAsync();
    }
}
