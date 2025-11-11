using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.UseCases;
using Mandalorian.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace Mandalorian.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices] IUseCase listadoMisionesUseCase)
        {
            ListaMisionesConMisionElegida misiones = new ListaMisionesConMisionElegida([]);
            ViewBag.errorMessage = string.Empty;
            try
            {
                misiones = listadoMisionesUseCase.getListaMisionesConMisionElegida();
                return View(misiones);
            } catch (Exception ex) {
                ViewBag.errorMessage = ex.Message;
                return View(misiones);
            }
            
        }

        // POST: Muestra la lista de misiones con la misión seleccionada
        [HttpPost]
        public IActionResult Seleccionar([FromServices] IUseCase listadoMisionesUseCase, int misionId)
        {
            ViewBag.errorMessage = string.Empty;

            try
            {
                // Si no se seleccionó ninguna misión, redirigir al Index
                if (misionId == 0)
                {
                    return RedirectToAction("Index");
                }

                // Obtener la lista de misiones con la misión seleccionada
                ListaMisionesConMisionElegida misiones =
                    listadoMisionesUseCase.getListaMisionesConMisionElegida(misionId);

                return View("Index", misiones);
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                ListaMisionesConMisionElegida misionesVacias = new ListaMisionesConMisionElegida([]);
                return View("Index", misionesVacias);
            }
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
