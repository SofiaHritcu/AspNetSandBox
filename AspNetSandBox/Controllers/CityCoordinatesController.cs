using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandBox.Controllers
{
    /// <summary>CityCoordinatesController gets city coordinates from third party api.</summary>
    [ApiController]
    [Route("[controller]")]
    public class CityCoordinatesController : ControllerBase
    {
        private string apiKey;
        private string cityName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityCoordinatesController"/> class.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        public CityCoordinatesController(string cityName)
        {
            this.apiKey = "56bb96d9fedf1b3044e60b0760f4278d";
            this.cityName = cityName;
        }

        /// <summary>Gets coordinates for city.</summary>
        /// <returns>
        ///   <para>city coordinates object.<br /></para>
        /// </returns>
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

        /// <summary>Converts the response from api to city coordinates.</summary>
        /// <param name="content">The content.</param>
        /// <returns>city coordinates object.<br /></returns>
        [NonAction]
        public CityCoordinates ConvertResponseToCityCoordinates(string content)
        {
            var cityJson = JObject.Parse(content);

            JToken cityCoordinates = cityJson["coord"];

            return new CityCoordinates
            {
                Lat = cityCoordinates.Value<double>("lat"),
                Long = cityCoordinates.Value<double>("lon"),
            };
        }
    }
}
