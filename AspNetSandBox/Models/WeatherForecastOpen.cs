using System;
using System.Collections.Generic;

namespace AspNetSandBox.Models
{
    /// <summary>Weather Forecast Open class.</summary>
    public class WeatherForecastOpen
    {
        /// <summary>Initializes a new instance of the <see cref="WeatherForecastOpen" /> class.</summary>
        /// <param name="currentTemperature">The current temperature.</param>
        /// <param name="currentDescription">The current description.</param>
        /// <param name="currentIconCode">The current icon code.</param>
        public WeatherForecastOpen(double currentTemperature, string currentDescription, string currentIconCode)
        {
            DailyForecasts = new List<DailyWeatherForecastOpen>();
            CurrentTemperature = currentTemperature;
            CurrentDescription = currentDescription;
            CurrentIconCode = currentIconCode;
        }

        /// <summary>Gets or sets the current temperature.</summary>
        /// <value>The current temperature.</value>
        public double CurrentTemperature { get; set; }

        /// <summary>Gets or sets the current description.</summary>
        /// <value>The current description.</value>
        public string CurrentDescription { get; set; }

        /// <summary>Gets or sets the current icon code.</summary>
        /// <value>The current icon code.</value>
        public string CurrentIconCode { get; set; }

        /// <summary>Gets or sets the daily forecasts.</summary>
        /// <value>The daily forecasts.</value>
        public List<DailyWeatherForecastOpen> DailyForecasts { get; set; }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "WeatherForecastOpen " + CurrentTemperature + " " + CurrentDescription + " " + CurrentIconCode + " ";
        }
    }
}
