using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AspNetSandBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastOpenController : ControllerBase
    {
        private readonly ILogger<WeatherForecastOpenController> _logger;
        private String keyAPI;
        private double latitude;
        private double longitude;

        public WeatherForecastOpenController(ILogger<WeatherForecastOpenController> logger)
        {
            _logger = logger;
            keyAPI = "56bb96d9fedf1b3044e60b0760f4278d";
            latitude = 45.657974;
            longitude = 25.601198;
        }

        [HttpGet]
        public WeatherForecastOpen Get()
        {
            // form url with given parameters
            String url = "https://api.openweathermap.org/data/2.5/onecall?lat=" + latitude.ToString() + "&lon=" + longitude.ToString() + "&exclude=hourly,minutely&units=metric&appid=" + keyAPI.ToString();
            Console.WriteLine(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // set method for http request
            request.Method = "GET";
            // set content type for http request
            request.ContentType = "application/json";
            // set type for response
            request.Accept = "application/json";
            WebResponse weatherForecastResponse = request.GetResponse();

            Stream weatherForecastStream = weatherForecastResponse.GetResponseStream();

            StreamReader weatherReadStream = new StreamReader(weatherForecastStream, Encoding.UTF8);

            string weather = weatherReadStream.ReadToEnd();

            weatherForecastResponse.Close();

            weatherReadStream.Close();

            // WeatherForecastOpen weatherForecastOpen =  JsonSerializer.Deserialize<WeatherForecastOpen>(weather);
            var deserializedWeather = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(weather);
            List<dynamic> dailyForecasts = new List<dynamic>(deserializedWeather.daily);
            List<DailyWeatherForecastOpen> dailyWeatherForecasts = new List<DailyWeatherForecastOpen>();
            for (int i = 0; i < dailyForecasts.Count; i++)
            {
                // deserialize daily forecasts
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                DateTime dateDaily = dtDateTime.AddSeconds((double)dailyForecasts[i].dt);
                int difference = 0;
                String timeFromNow = "";
                if ( i == 0 )
                {
                    difference = (dateDaily - DateTime.Now).Hours;
                    timeFromNow = "in " + difference + " hours";
                } else
                {
                    if ( i == 1)
                    {
                        difference = (dateDaily - DateTime.Now).Days;
                        timeFromNow = "in " + difference + " day";
                    } else
                    {
                        difference = (dateDaily - DateTime.Now).Days;
                        timeFromNow = "in " + difference + " days";
                    }
                }

                double dailyTemperature = dailyForecasts[i].temp.day;
                double windSpeed = dailyForecasts[i].wind_speed;
                String dailyDescription = dailyForecasts[i].weather[0].description;
                String dailyIconCode = dailyForecasts[i].weather[0].icon;

                DailyWeatherForecastOpen dailyWeather = new DailyWeatherForecastOpen(timeFromNow, dailyTemperature, windSpeed, dailyDescription, dailyIconCode);
                dailyWeatherForecasts.Add(dailyWeather);
            }

            // constri=uct forecast containg daily forecasts
            double currentTemperature = (double)deserializedWeather.current.temp;
            String currentDescription = deserializedWeather.current.weather[0].description;
            String currentIcon = deserializedWeather.current.weather[0].icon;
            WeatherForecastOpen weatherForecast = new WeatherForecastOpen(currentTemperature, currentDescription, currentIcon);
            weatherForecast.DailyForecasts = dailyWeatherForecasts;
            return weatherForecast;
        }

       
    }
}
