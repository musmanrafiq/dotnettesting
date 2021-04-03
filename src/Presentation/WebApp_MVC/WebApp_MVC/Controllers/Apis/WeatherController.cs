using Microsoft.AspNetCore.Mvc;
using OpenWeatheWrapper.Interfaces;
using OpenWeatheWrapper.Models;
using System.Threading.Tasks;

namespace WebApp_MVC.Controllers.Apis
{

    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWheatherService _wheatherService;

        public WeatherController(IWheatherService weatherService)
        {
            _wheatherService = weatherService;
        }

        [HttpGet]
        public async Task<WeatherModel> Get()
        {
            var record = await _wheatherService.GetWeatherByCity("Islamabad");
            return record;
        }
    }
}
