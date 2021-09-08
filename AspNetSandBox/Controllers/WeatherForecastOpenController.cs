using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetSandBox.Controllers
{
    /// <summary>Weather Forecast for 7 days using third party api.</summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastOpenController : ControllerBase
    {
        private string keyAPI;
        private double latitude;
        private double longitude;

        /// <summary>Initializes a new instance of the <see cref="WeatherForecastOpenController" /> class.</summary>
        public WeatherForecastOpenController()
        {
            keyAPI = "56bb96d9fedf1b3044e60b0760f4278d";
            latitude = 45.657974;
            longitude = 25.601198;
        }

        /// <summary>Gets weather forecasts for the current day and the 7 days after it.</summary>
        /// <returns>Weather Forecast Open object.</returns>
        [HttpGet]
        public WeatherForecastOpen Get()
        {
            // form url with given parameters
            string url = "https://api.openweathermap.org/data/2.5/onecall?lat=" + latitude.ToString() + "&lon=" + longitude.ToString() + "&exclude=hourly,minutely&units=metric&appid=" + keyAPI.ToString();
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
                string timeFromNow = string.Empty;
                if (i == 0)
                {
                    difference = (dateDaily - DateTime.Now).Hours;
                    timeFromNow = "in " + difference + " hours";
                }
                else
                {
                    if (i == 1)
                    {
                        difference = (dateDaily - DateTime.Now).Days;
                        timeFromNow = "in " + difference + " day";
                    }
                    else
                    {
                        difference = (dateDaily - DateTime.Now).Days;
                        timeFromNow = "in " + difference + " days";
                    }
                }

                double dailyTemperature = dailyForecasts[i].temp.day;
                double windSpeed = dailyForecasts[i].wind_speed;
                string dailyDescription = dailyForecasts[i].weather[0].description;
                string dailyIconCode = dailyForecasts[i].weather[0].icon;

                DailyWeatherForecastOpen dailyWeather = new DailyWeatherForecastOpen(timeFromNow, dailyTemperature, windSpeed, dailyDescription, dailyIconCode);
                dailyWeatherForecasts.Add(dailyWeather);
            }

            // constri=uct forecast containg daily forecasts
            double currentTemperature = (double)deserializedWeather.current.temp;
            string currentDescription = deserializedWeather.current.weather[0].description;
            string currentIcon = deserializedWeather.current.weather[0].icon;
            WeatherForecastOpen weatherForecast = new WeatherForecastOpen(currentTemperature, currentDescription, currentIcon);
            weatherForecast.DailyForecasts = dailyWeatherForecasts;
            return weatherForecast;
        }
    }
}
