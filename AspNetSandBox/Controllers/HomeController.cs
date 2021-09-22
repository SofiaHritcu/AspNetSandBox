using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetSandBox.Controllers
{
    /// <summary>HomeController.</summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        /// <summary>Initializes a new instance of the <see cref="HomeController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>Indexes this instance.</summary>
        /// <returns>View of Index.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>Privacies this instance.</summary>
        /// <returns>View.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>Errors this instance.</summary>
        /// <returns>View with Error.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
