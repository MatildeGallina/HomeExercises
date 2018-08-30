using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeteoFVG.Models;

namespace MeteoFVG.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var cities = new List<CityWeather>()
            {
                new CityWeather(1, "Pordenone", 25, Weather.Cloudy),
                new CityWeather(2, "Udine", 22, Weather.Raing),
                new CityWeather(3, "Gorizia", 27, Weather.Sunny),
                new CityWeather(4, "Trieste", 30, Weather.Sunny)
            };
            return View(cities);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
