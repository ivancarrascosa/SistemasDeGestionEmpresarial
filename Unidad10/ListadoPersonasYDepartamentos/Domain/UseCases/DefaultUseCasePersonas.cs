using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DefaultUseCasePersonas : IUseCasePersonas
    {
        private readonly IRepositoryPersonas _repositoryPersonas;
        private readonly IRepositoryDepartamentos _repositoryDepartamentos;

        public DefaultUseCasePersonas(IRepositoryPersonas repositoryPersonas, IRepositoryDepartamentos repositoryDepartamentos)
        {
            _repositoryPersonas = repositoryPersonas;
            _repositoryDepartamentos = repositoryDepartamentos;
        }

        public int ActualizarPersona(int id, Persona persona)
        {
            throw new NotImplementedException();
        }

        public int CrearPersona(Persona persona)
        {
            throw new NotImplementedException();
        }

        public int EliminarPersona(int id)
        {
            throw new NotImplementedException();
        }

        public PersonaConNombreDeDepartamentoDTO GetDetallePersona(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonaConNombreDeDepartamentoDTO> getListaPersonasConDepartamento()
        {
            String nombreDepartamento = "";
            List<PersonaConNombreDeDepartamentoDTO> listaPersonasConNombreDepartamento = [];
            List<Departamento> listaDepartamentos = _repositoryDepartamentos.getListaDepartamentos().ToList();
            foreach (Persona persona in _repositoryPersonas.getListaPersonas())
            {
                nombreDepartamento = listaDepartamentos.Where(departamento => departamento.id == persona.idDepartamento).First().nombre;
                listaPersonasConNombreDepartamento.Add(new PersonaConNombreDeDepartamentoDTO(persona.id, persona.nombre,persona.apellido, persona.direccion, persona.telefono, persona.fechaNac, persona.imagen, nombreDepartamento));
            }
            return listaPersonasConNombreDepartamento;
        }

        public PersonaConListaDeDepartamentosDTO GetPersonaParaCrear()
        {
            throw new NotImplementedException();
        }

        public PersonaConListaDeDepartamentosDTO GetPersonaConListaDepartamentos(int id)
        {
            throw new NotImplementedException();
        }
    }
}
