using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWeatheWrapper.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWheatherService _wheatherService;

        public HomeController(IWheatherService weatherService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _wheatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            var record = await _wheatherService.GetWeatherByCity("Islamabad");
            return View(record);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
