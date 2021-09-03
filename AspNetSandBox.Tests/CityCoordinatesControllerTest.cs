﻿using AspNetSandBox.Controllers;
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
        private string LoadJsonFromResource(string city)
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromWeatherApiCityCoordinates"+city+".json";
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
            LoadJson loader = new LoadJson();
            string coordinatesJson = loader.LoadJsonFromResource("DataFromWeatherApiCityCoordinatesBucharest");
            CityCoordinatesController cityCoordinatesController = new CityCoordinatesController("Bucharest");

            //Act
            CityCoordinates cityCoordinates = cityCoordinatesController.ConvertResponseToCityCoordinates(coordinatesJson);

            //Assert
            Assert.Equal(26.1063, cityCoordinates.Long);
            Assert.Equal(44.4323, cityCoordinates.Lat);
        
        }

        [Fact]
        public void ShouldConvertResponseToAtheneCoordinates()
        {
            //Assume
            LoadJson loader = new LoadJson();
            string coordinatesJson = loader.LoadJsonFromResource("DataFromWeatherApiCityCoordinatesAthene");
            CityCoordinatesController cityCoordinatesController = new CityCoordinatesController("Athene");

            //Act
            CityCoordinates cityCoordinates = cityCoordinatesController.ConvertResponseToCityCoordinates(coordinatesJson);

            //Assert
            Assert.Equal(23.7162, cityCoordinates.Long);
            Assert.Equal(37.9795, cityCoordinates.Lat);
        }

        [Fact]
        public void ShouldConvertResponseToChicagoCoordinates()
        {
            //Assume
            LoadJson loader = new LoadJson();
            string coordinatesJson = loader.LoadJsonFromResource("DataFromWeatherApiCityCoordinatesChicago");
            CityCoordinatesController cityCoordinatesController = new CityCoordinatesController("Chicago");

            //Act
            CityCoordinates cityCoordinates = cityCoordinatesController.ConvertResponseToCityCoordinates(coordinatesJson);

            //Assert
            Assert.Equal(-87.65, cityCoordinates.Long);
            Assert.Equal(41.85, cityCoordinates.Lat);
        }

    }

}