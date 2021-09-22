using System;
using System.Collections.Generic;
using System.IO;
using AspNetSandBox.Controllers;
using AspNetSandBox.Models;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>WeatherForecastControllerTest Class.</summary>
    public class WeatherForecastControllerTest
    {
        /// <summary>Shoulds the convert response to weather forecast.</summary>
        [Fact]
        public void ShouldConvertResponseToWeatherForecast()
        {
            // Assume
            string content = LoadJson.LoadJsonFromResource("DataFromWeatherApi");
            var weatherForecastController = new WeatherForecastController();

            // Act
            IEnumerable<WeatherForecast> weatherForecasts = weatherForecastController.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])weatherForecasts)[0];
            Assert.Equal("Clear", weatherForecastForTomorrow.Summary);
            Assert.Equal(18, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 3), weatherForecastForTomorrow.Date);
        }

        /// <summary>Shoulds the convert response to weather forecast after tomorrow.</summary>
        [Fact]
        public void ShouldConvertResponseToWeatherForecastAfterTomorrow()
        {
            // Assume
            string content = LoadJson.LoadJsonFromResource("DataFromWeatherApi");
            var weatherForecastController = new WeatherForecastController();

            // Act
            IEnumerable<WeatherForecast> weatherForecasts = weatherForecastController.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForDayAfterTomorrow = ((WeatherForecast[])weatherForecasts)[1];
            Assert.Equal("Clear", weatherForecastForDayAfterTomorrow.Summary);
            Assert.Equal(20, weatherForecastForDayAfterTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 4), weatherForecastForDayAfterTomorrow.Date);
        }
    }
}
