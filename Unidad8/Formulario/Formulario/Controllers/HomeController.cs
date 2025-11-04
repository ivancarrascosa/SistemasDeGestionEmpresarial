using System.Diagnostics;
using Formulario.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Formulario.Controllers
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

        [HttpPost]
        public IActionResult Index(Persona persona)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Saludo(String nombre)
        {
            @ViewBag.nombre = nombre;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Ejercicio2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ejercicio2(String nombre)
        {
            return RedirectToAction("Saludo", new { nombre = nombre });
        }
    }
}
