using Microsoft.Extensions.Options;
using OpenWeatheWrapper.Interfaces;
using OpenWeatheWrapper.IOptions;
using OpenWeatheWrapper.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OpenWeatheWrapper.Services
{
    public class WheatherService : IWheatherService
    {
        private readonly HttpClient _client;
        private readonly OpenWeatherOptions _weatherOptions;

        public WheatherService(IHttpClientFactory clientFactory, IOptionsSnapshot<OpenWeatherOptions> options)
        {
            _client = clientFactory.CreateClient("WeatherApiClient");
            _weatherOptions = options.Value;
        }
        public async Task<WeatherModel> GetWeatherByCity(string cityName)
        {
            WeatherModel model = null;
            HttpResponseMessage response = await _client.GetAsync($"/data/2.5/weather?q={cityName}&appid={_weatherOptions.AppId}");
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadFromJsonAsync<WeatherModel>();
            }
            return model;
        }
    }
}
