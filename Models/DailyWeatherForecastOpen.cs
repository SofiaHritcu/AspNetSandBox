using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.Models
{
    public class DailyWeatherForecastOpen
    {
       
        public String TimeFromNow { get; set; }

        public double DailyTemperature { get; set; }

        public double WindSpeed { get; set; }

        public String DailyDescription { get; set; }

        public String DailyIconCode { get; set; }

        public DailyWeatherForecastOpen(string timeFromNow, double dailyTemperature, double windSpeed, string dailyDescription, string dailyIconCode)
        {
            TimeFromNow = timeFromNow;
            DailyTemperature = dailyTemperature;
            WindSpeed = windSpeed;
            DailyDescription = dailyDescription;
            DailyIconCode = dailyIconCode;
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
            return "DailyWeatherForecastOpen " + TimeFromNow + " " + WindSpeed + " " + DailyDescription + " " + DailyIconCode;
        }
    }
}
