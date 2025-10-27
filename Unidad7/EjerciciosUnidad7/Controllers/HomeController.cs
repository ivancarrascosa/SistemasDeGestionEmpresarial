using System.Diagnostics;
using EjerciciosUnidad7.Models;
using EjerciciosUnidad7.Models.Entities;
using EjerciciosUnidad7.Models.Entities.DAL;
using EjerciciosUnidad7.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EjerciciosUnidad7.Controllers
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
            var hora = DateTime.Now;
            var mensaje = "";
            var persona = new Persona(1, "Iván", "Carrascosa", 2);
            if (hora.Hour < 12)
            {
                mensaje = "Buenos días";
            }
            else if (hora.Hour < 20)
            {
                mensaje = "Buenas tardes";
            } else
            {
                mensaje = "buenas noches";
            }
            ViewData["Hora"] = hora.ToShortTimeString();
            ViewBag.mensaje = mensaje;

            return View(persona);
        }

        public IActionResult ListadoPersonas()
        {
            ListadoPersonas listadoPersonas = new ListadoPersonas();
            return View(listadoPersonas);
        }

        public IActionResult EditarPersona()
        {
            /// El random lo tiene que hacer la clase, no el controlador 
            PersonaDepartamentosViewModel modelo = new PersonaDepartamentosViewModel();
            return View(modelo);
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
    }
}
