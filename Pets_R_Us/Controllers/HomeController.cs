using Microsoft.AspNetCore.Mvc;
using Pets_R_Us.Models;
using System.Diagnostics;

namespace Pets_R_Us.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OurServices()
        {
            return View();
        }
        public IActionResult OurPeople()
        {
            return View();
        }
        public IActionResult OurLocation()
        {
            return View();
        }
        public IActionResult LoggedContact()
        { 
            return View();
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}