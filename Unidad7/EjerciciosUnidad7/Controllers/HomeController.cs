using System.Diagnostics;
using EjerciciosUnidad7.Models;
using EjerciciosUnidad7.Models.Entities;
using EjerciciosUnidad7.Models.Entities.DAL;
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
            var persona = new Persona(1, "Iv�n", "Carrascosa");
            if (hora.Hour < 12)
            {
                mensaje = "Buenos d�as";
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
            Persona persona1 = new Persona(1, "Juan", "P�rez");
            Persona persona2 = new Persona(2, "Mar�a", "Gonz�lez");
            Persona persona3 = new Persona(3, "Luis", "Mart�nez");
            Persona persona4 = new Persona(4, "Ana", "L�pez");
            Persona persona5 = new Persona(5, "Carlos", "Ram�rez");
            Persona persona6 = new Persona(6, "Laura", "D�az");

            // Lista para guardar las personas (opcional)
            List<Persona> personas = new List<Persona>
            {
                persona1, persona2, persona3, persona4, persona5, persona6
            };
            ListadoPersonas listadoPersonas = new ListadoPersonas(personas);
            return View(listadoPersonas);
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
