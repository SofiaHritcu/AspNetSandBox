using AspNetSandBox.Controllers;
using AspNetSandBox.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class CityCoordinatesControllerTest
    {
        [Fact]
        public void ShouldConvertResponseToBucharestCoordinates()
        {
            // Assume
            string coordinatesJson = LoadJson.LoadJsonFromResource("DataFromWeatherApiCityCoordinatesBucharest");
            CityCoordinatesController cityCoordinatesController = new CityCoordinatesController("Bucharest");

            // Act
            CityCoordinates cityCoordinates = cityCoordinatesController.ConvertResponseToCityCoordinates(coordinatesJson);

            // Assert
            Assert.Equal(26.1063, cityCoordinates.Long);
            Assert.Equal(44.4323, cityCoordinates.Lat);
        }

        [Fact]
        public void ShouldConvertResponseToAtheneCoordinates()
        {
            // Assume
            string coordinatesJson = LoadJson.LoadJsonFromResource("DataFromWeatherApiCityCoordinatesAthene");
            CityCoordinatesController cityCoordinatesController = new CityCoordinatesController("Athene");

            // Act
            CityCoordinates cityCoordinates = cityCoordinatesController.ConvertResponseToCityCoordinates(coordinatesJson);

            // Assert
            Assert.Equal(23.7162, cityCoordinates.Long);
            Assert.Equal(37.9795, cityCoordinates.Lat);
        }

        [Fact]
        public void ShouldConvertResponseToChicagoCoordinates()
        {
            // Assume
            string coordinatesJson = LoadJson.LoadJsonFromResource("DataFromWeatherApiCityCoordinatesChicago");
            CityCoordinatesController cityCoordinatesController = new CityCoordinatesController("Chicago");

            // Act
            CityCoordinates cityCoordinates = cityCoordinatesController.ConvertResponseToCityCoordinates(coordinatesJson);

            // Assert
            Assert.Equal(-87.65, cityCoordinates.Long);
            Assert.Equal(41.85, cityCoordinates.Lat);
        }
    }
}
