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
            string content = "{\"coord\":{\"lon\":26.0963,\"lat\":44.4397},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"base\":\"stations\",\"main\":{\"temp\":292.36,\"feels_like\":291.98,\"temp_min\":290.83,\"temp_max\":295.87,\"pressure\":1015,\"humidity\":63},\"visibility\":10000,\"wind\":{\"speed\":0.89,\"deg\":245,\"gust\":2.24},\"clouds\":{\"all\":0},\"dt\":1630565300,\"sys\":{\"type\":2,\"id\":2032494,\"country\":\"RO\",\"sunrise\":1630553977,\"sunset\":1630601486},\"timezone\":10800,\"id\":676742,\"name\":\"Grefoaicele\",\"cod\":200}";
            WeatherForecastController weatherForecastController = new WeatherForecastController();

            // Act
            IEnumerable<WeatherForecast> weatherForecasts =  weatherForecastController.ConvertResponseToWeatherForecast(content);
            //var weatherForecast = weatherForecastController.ConvertResponseToWeatherForecast(content);

            // Assert
            Assert.Equal("rainy", ((WeatherForecast[])weatherForecasts)[0].Summary);
        }
    }
}
