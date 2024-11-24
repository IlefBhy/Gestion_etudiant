using Gestion_etudiant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gestion_etudiant.Controllers
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
            return View(); // Make sure Index.cshtml exists in Views/Home
        }

    }
}
