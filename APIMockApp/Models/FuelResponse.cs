using System;
using System.Text.Json.Serialization;

namespace APIMockApp.Models
{
    public class FuelResponse
    {

        [JsonPropertyName("gasolinaPremium")]
        public string GasolinaPremium { get; set; }

        [JsonPropertyName("gasolinaRegular")]
        public string GasolinaRegular { get; set; }

        [JsonPropertyName("gasoilOptimo")]
        public string GasoilOptimo { get; set; }

        [JsonPropertyName("gasoilRegular")]
        public string GasoilRegular { get; set; }

        [JsonPropertyName("kerosene")]
        public string Kerosene { get; set; }

        [JsonPropertyName("gasLicuadoPetroleoGLP")]
        public string GasLicuadoPetroleoGLP { get; set; }

        [JsonPropertyName("gasNaturalVehicularGNV")]
        public string GasNaturalVehicularGNV { get; set; }
    }


}
