using System;
using System.Net.Http;
using System.Threading.Tasks;
using APIMockApp.Models;
using Refit;

namespace APIMockApp.Services
{
    public interface IFuelApi
    {
        // http://eladio37-001-site1.ftempurl.com/api/Fuels
        [Get("/api/Fuels")]
        Task<HttpResponseMessage> GetFuelsAsync();
    }
}
