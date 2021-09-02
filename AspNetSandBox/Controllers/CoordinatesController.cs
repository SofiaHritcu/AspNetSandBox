using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatesController : ControllerBase
    {
        private string apiKey;
        private string cityName;
        public CoordinatesController(string apiKey, string cityName)
        {
            this.apiKey = apiKey;
            this.cityName = cityName;
        }

        [HttpGet]
        public IEnumerable<Coordinates> Get()
        {   // Berlin 56bb96d9fedf1b3044e60b0760f4278d .AddParameter("q", "Berlin")
            var client = new RestClient("https://api.openweathermap.org/data/2.5//weather");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET).AddQueryParameter("q", "Berlin").AddQueryParameter("appid", "56bb96d9fedf1b3044e60b0760f4278d");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return new List<Coordinates>();

        }

        public IEnumerable<Coordinates> ConvertResponseToWeatherForecast(string content)
        {
            return new List<Coordinates>();
        }

        
    }
}
