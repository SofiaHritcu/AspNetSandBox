using AspNetSandBox.Controllers;
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
        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromWeatherApiCityCoordinates.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();

            }
        }

        [Fact]
        public void ShouldConvertResponseToBucharestCoordinates()
        {
            //Assume
            string coordinatesJson = LoadJsonFromResource();
            CityCoordinatesController cityCoordinatesController = new CityCoordinatesController("Bucharest");

            //Act
            CityCoordinates cityCoordinates = cityCoordinatesController.ConvertResponseToCityCoordinates(coordinatesJson);

            //Assert
            Assert.Equal(26.1063, cityCoordinates.Long);
            Assert.Equal(44.4323, cityCoordinates.Lat);
        
        }

    }

}
