using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Mappers;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DefaultUseCase : IUseCase
    {
        private readonly IRepository _repository;

        public DefaultUseCase(IRepository repository)
        {
            _repository = repository;
        }
        public PersonaConNombreDeDepartamentoDTO[] getListaPersonasConDepartamento()
        {
            List<PersonaConNombreDeDepartamentoDTO> listaPersonasConNombreDepartamento = [];
            List<Departamento> listaDepartamentos = _repository.getListaDepartamentos().ToList();
            foreach (Persona persona in _repository.getListaPersonas())
            {
                listaPersonasConNombreDepartamento.Add(PersonaToPersonaConDepartamentoDTO.Mappers(persona, listaDepartamentos));
            }
            return listaPersonasConNombreDepartamento.ToArray();
        }
    }
}
