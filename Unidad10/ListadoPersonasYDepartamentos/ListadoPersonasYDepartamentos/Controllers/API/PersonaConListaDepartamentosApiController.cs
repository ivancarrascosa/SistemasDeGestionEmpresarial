using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaConListaDepartamentosApiController : ControllerBase
    {
        IUseCasePersonas _personasUseCase;

        public PersonaConListaDepartamentosApiController(IUseCasePersonas useCasePersonas)
        {
            _personasUseCase = useCasePersonas;
        }
        // GET: api/<PersonaConListaDepartamentosApiController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaConListaDeDepartamentosDTO> listadoCompleto = new List<PersonaConListaDeDepartamentosDTO>();

            try
            {

                listadoCompleto = _personasUseCase.getListaPersonasConListaDepartamentos();
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

        // GET api/<PersonaConListaDepartamentosApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            PersonaConListaDeDepartamentosDTO persona;
            try
            {
                persona = _personasUseCase.GetPersonaConListaDepartamentos(id);
                if (persona == null)
                {
                    salida = NoContent();
                }
                else
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
    }
}
