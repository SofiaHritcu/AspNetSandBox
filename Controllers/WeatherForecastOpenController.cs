using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public String Get()
        {
            //https://api.openweathermap.org/data/2.5/onecall?lat=45.657974&lon=25.601198&exclude=hourly,minutely&units=metric&appid=56bb96d9fedf1b3044e60b0760f4278d
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

            Console.WriteLine(weather);
            return weather;
        }
    }
}
