﻿using System;
using System.Threading.Tasks;
using APIMockApp.Models;
using Refit;

namespace APIMockApp.Services
{
    public interface IFuelApiService
    {
        
        Task<FuelResponse> GetFuelsAsync();
    }
}
