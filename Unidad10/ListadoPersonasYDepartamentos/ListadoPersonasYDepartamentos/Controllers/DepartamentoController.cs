using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IUseCaseDepartamentos _useCase;

        public DepartamentoController(IUseCaseDepartamentos useCase)
        {
            _useCase = useCase;
        }

        // GET: DepartamentoController
        public ActionResult Index()
        {
            var deptos = _useCase.GetDepartamentos();
            return View(deptos);
        }

        // GET: DepartamentoController/Details/5
        public ActionResult Details(int id)
        {
            var dept = _useCase.GetDetalleDepartamento(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        // GET: DepartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                _useCase.CrearDepartamento(departamento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(departamento);
            }
        }

        // GET: DepartamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            var dept = _useCase.GetDepartamentoParaEditar(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        // POST: DepartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departamento departamento)
        {
            try
            {
                _useCase.ActualizarDepartamento(departamento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(departamento);
            }
        }

        // GET: DepartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            var dept = _useCase.GetDetalleDepartamento(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        // POST: DepartamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                _useCase.EliminarDepartamento(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
