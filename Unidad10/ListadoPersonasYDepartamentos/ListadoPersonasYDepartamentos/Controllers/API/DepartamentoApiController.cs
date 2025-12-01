using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoApiController : ControllerBase
    {
        IUseCaseDepartamentos _departamentosUseCase;

        public DepartamentoApiController(IUseCaseDepartamentos useCaseDepartamentos)
        {
            _departamentosUseCase = useCaseDepartamentos;
        }
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Departamento> listadoCompleto = new List<Departamento>();

            try
            {

                listadoCompleto = _departamentosUseCase.GetDepartamentos();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            Departamento departamento;
            try
            {
                departamento = _departamentosUseCase.GetDetalleDepartamento(id);
                if (departamento == null)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(departamento);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post(Departamento departamento)
        {
            IActionResult salida;
            int filasAfectadas;
            try
            {
                filasAfectadas = _departamentosUseCase.CrearDepartamento(departamento);
                if (filasAfectadas == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(departamento);
                }
            }
            catch { salida = BadRequest(); }
            return salida;
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,Departamento departamento)
        {
            IActionResult salida;
            int filasAfectadas;
            try
            {
                filasAfectadas = _departamentosUseCase.ActualizarDepartamento(departamento);
                if (filasAfectadas == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(departamento);
                }
            }
            catch { salida = BadRequest(); }
            return salida;
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int filasAfectadas;
            try
            {
                filasAfectadas = _departamentosUseCase.EliminarDepartamento(id);
                if (filasAfectadas == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(id);
                }
            }
            catch { salida = BadRequest(); }
            return salida;
        }
    }
}
