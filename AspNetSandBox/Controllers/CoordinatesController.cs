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
        public IEnumerable<Coordinates> Get()
        {
            return new List<Coordinates>();

        }

        public IEnumerable<Coordinates> ConvertResponseToWeatherForecast(string content)
        {
            return new List<Coordinates>();
        }

        
    }
}
