using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasApiController : ControllerBase
    {
        IUseCasePersonas _personasUseCase;

        public PersonasApiController(IUseCasePersonas useCasePersonas) {
            _personasUseCase = useCasePersonas;
        }
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Persona> listadoCompleto = new List<Persona>();

            try
            {

                listadoCompleto = _personasUseCase.getPersonas();
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

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            Persona persona;
            try
            {
                persona = _personasUseCase.getPersona(id);
                if (persona == null)
                {
                    salida= NoContent();
                } else
                {
                    salida = Ok(persona);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post(Persona persona)
        {
            IActionResult salida;
            int filasAfectadas;
            try
            {
                filasAfectadas = _personasUseCase.CrearPersona(persona);
                if (filasAfectadas == 0)
                {
                    salida = NoContent();
                } else
                {
                    salida = Ok(persona);
                }
            }
            catch { salida = BadRequest(); }
            return salida;

        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Persona persona)
        {
            IActionResult salida;
            int filasAfectadas;
            try
            {
                filasAfectadas = _personasUseCase.ActualizarPersona(id, persona);
                if (filasAfectadas == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch { salida = BadRequest(); }
            return salida;
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int filasAfectadas;
            try
            {
                filasAfectadas = _personasUseCase.EliminarPersona(id);
                if (filasAfectadas == 0)
                {
                    salida = NoContent();
                } else
                {
                    salida = Ok(id);
                }
            } 
            catch { salida = BadRequest(); }
            return salida;
        }
    }
}
