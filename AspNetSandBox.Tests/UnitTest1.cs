using AspNetSandBox.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void ShouldConvertResponseToWeatherForecast()
        {
            // Assume
            string content = "";
            WeatherForecastController weatherForecastController = new WeatherForecastController();

            // Act
            IEnumerable<WeatherForecast> weatherForecasts =  weatherForecastController.ConvertResponseToWeatherForecast(content);
            //var weatherForecast = weatherForecastController.ConvertResponseToWeatherForecast(content);

            // Assert
            Assert.Equal("rainy", ((WeatherForecast[])weatherForecasts)[0].Summary);
        }
    }
}
