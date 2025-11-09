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
            return View(listadoMisionesUseCase.getMisiones());
        }

        [HttpPost]
        public IActionResult Index(IndexVM model)
        {
            var misiones = _useCase.getMisiones();
            var seleccionada = misiones.FirstOrDefault(m => m.Id == model.MisionSeleccionadaId);

            var vm = new IndexVM(misiones, seleccionada);
            return View(vm);
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
