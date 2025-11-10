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
            List<Mision> misiones = [];
            ViewBag.errorMessage = string.Empty;
            try
            {
                misiones = listadoMisionesUseCase.getMisiones();
                return View(misiones);
            } catch (Exception ex) {
                ViewBag.errorMessage = ex.Message;
                return View(misiones);
            }
            
        }


        [HttpPost]
        public IActionResult Index(misionId int)
        {
            
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
