using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class PersonaToPersonaConDepartamentoDTO
    {
        public static PersonaConNombreDeDepartamentoDTO Mappers(Persona persona, List<Departamento> listaDepartamentos)
        {
            int idDepartamento = persona.idDepartamento;
            var departamento = listaDepartamentos.Find(d => d.id == idDepartamento);

            if (departamento == null)
            {
                throw new Exception("Departamento no encontrado");
            }
            string nombreDepartamento = departamento.nombre;
            return new PersonaConNombreDeDepartamentoDTO(persona.id, persona.nombre, persona.apellido, persona.direccion, persona.telefono, persona.fechaNac, persona.imagen, nombreDepartamento);
        }
    }
}
