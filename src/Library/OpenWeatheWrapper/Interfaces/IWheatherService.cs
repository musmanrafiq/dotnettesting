using OpenWeatheWrapper.Models;
using System.Threading.Tasks;

namespace OpenWeatheWrapper.Interfaces
{
    public interface IWheatherService
    {
        Task<WeatherModel> GetWeatherByCity(string cityName);
    }
}
