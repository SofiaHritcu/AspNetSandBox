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
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherForecastController()
        {

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=45.657974&lon=25.601198&exclude=hourly,minutely&appid=56bb96d9fedf1b3044e60b0760f4278d");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content);

        }

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content)
        {
            var json = JObject.Parse(content);
            var rng = new Random();
            
            return Enumerable.Range(1, 5).Select(index =>
            {
                JToken jsonDailyWeather = json["daily"][index];
                long unixDateTime = jsonDailyWeather.Value<long>("dt");
                
                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = (int)Math.Round(jsonDailyWeather["temp"].Value<double>("day") - 273.15),
                    Summary = jsonDailyWeather["weather"][0].Value<string>("main")
                };
            })
            .ToArray();
        }
    }
}
