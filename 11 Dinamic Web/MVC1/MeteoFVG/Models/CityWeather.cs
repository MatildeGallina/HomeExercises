using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteoFVG.Models
{
    public class CityWeather
    {
        public CityWeather(int id, string city, int temperature, Weather weather)
        {
            Id = id;
            City = city;
            Temperature = temperature;
            Weather = weather;
        }

        public int Id { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }
        public Weather Weather { get; set; }
    }

    public enum Weather{
        Sunny,
        Cloudy,
        Raing
    }
}
