using System;
using System.Collections.Generic;
using System.Linq;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandBox.Controllers
{
    /// <summary>
    /// Controller that allows us to get weather forecast from third party API.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVINCONST = 273.15f;

        /// <summary>
        ///  Getting weather forecast for 5 days.
        /// </summary>
        /// <returns>
        /// Enumerable of weather forecast objects.
        /// </returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=45.657974&lon=25.601198&exclude=hourly,minutely&appid=56bb96d9fedf1b3044e60b0760f4278d");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return ConvertResponseToWeatherForecast(response.Content);
        }

        /// <summary>Converts the response to weather forecast.</summary>
        /// <param name="content">The content.</param>
        /// <param name="days">The days.</param>
        /// <returns>Weather Forecast object.</returns>
        [NonAction]
        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
        {
            var json = JObject.Parse(content);
            var rng = new Random();
            return Enumerable.Range(1, days).Select(index =>
            {
                var jsonDailyWeather = json["daily"][index];
                long unixDateTime = jsonDailyWeather.Value<long>("dt");
                var weatherSummary = jsonDailyWeather["weather"][0].Value<string>("main");

                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(jsonDailyWeather),
                    Summary = weatherSummary,
                };
            })
            .ToArray();
        }

        [NonAction]
        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyWeather)
        {
            return (int)Math.Round(jsonDailyWeather["temp"].Value<double>("day") - KELVINCONST);
        }
    }
}
