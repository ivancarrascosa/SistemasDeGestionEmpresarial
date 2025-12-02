using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaConDepartamentoController : ControllerBase
    {
        IUseCasePersonas _personasUseCase;

        public PersonaConDepartamentoController(IUseCasePersonas useCasePersonas)
        {
            _personasUseCase = useCasePersonas;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaConNombreDeDepartamentoDTO> listadoCompleto = new List<PersonaConNombreDeDepartamentoDTO>();

            try
            {

                listadoCompleto = _personasUseCase.getListaPersonasConDepartamento();
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

        // GET: PersonaConDepartamentoApiController/Details/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            PersonaConNombreDeDepartamentoDTO persona;
            try
            {
                persona = _personasUseCase.GetDetallePersona(id);
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
