using AspNetSandBox.Controllers;
using AspNetSandBox.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class WeatherForecastControllerTest
    {
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
