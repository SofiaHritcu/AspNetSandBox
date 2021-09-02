using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityCoordinatesController : ControllerBase
    {
        private string apiKey;
        private string cityName;

        public CityCoordinatesController(string apiKey = "56bb96d9fedf1b3044e60b0760f4278d", string cityName = "London")
        {
            this.apiKey = apiKey;
            this.cityName = cityName;
        }

        [HttpGet]
        public CityCoordinates Get()
        {   
            var client = new RestClient("https://api.openweathermap.org/data/2.5//weather");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET).AddQueryParameter("q", cityName).AddQueryParameter("appid", apiKey);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToCityCoordinates(response.Content);
        }

        public CityCoordinates ConvertResponseToCityCoordinates(string content)
        {
            var cityJson = JObject.Parse(content);

            JToken cityCoordinates = cityJson["coord"];

            return new CityCoordinates
            {
                Lat = cityCoordinates.Value<double>("lat"),
                Long = cityCoordinates.Value<double>("lon")
            };
        }
        
    }
}
