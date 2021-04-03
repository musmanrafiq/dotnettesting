using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatheWrapper.Interfaces
{
    public interface IWheatherService
    {
        Task GetWeatherByCity(string cityName);
    }
}
