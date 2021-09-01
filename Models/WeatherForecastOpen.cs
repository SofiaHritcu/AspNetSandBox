using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.Models
{
    public class WeatherForecastOpen
    {
        public double CurrentTemperature { get; set; }

        public String CurrentDescription { get; set; }

        public String CurrentIconCode { get; set; }

        public List<DailyWeatherForecastOpen> DailyForecasts { get; set; }

        public WeatherForecastOpen(double currentTemperature, string currentDescription, string currentIconCode)
        {
            DailyForecasts = new List<DailyWeatherForecastOpen>();
            CurrentTemperature = currentTemperature;
            CurrentDescription = currentDescription;
            CurrentIconCode = currentIconCode;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "WeatherForecastOpen " + CurrentTemperature + " " + CurrentDescription + " " + CurrentIconCode + " " ;
        }
    }
}
