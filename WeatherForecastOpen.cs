using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox
{
    public class WeatherForecastOpen
    {
        public float CurrentTemperature { get; set; }

        public String CurrentDescription { get; set; }

        public String CurrentIconCode { get; set; }

        public ICollection<DailyWeatherForecastOpen> DailyForecasts { get; set; }

    }
}
