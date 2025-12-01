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

        /// <summary>
        ///     <header>public DefaultUseCasePersonas(IRepositoryPersonas repositoryPersonas, IRepositoryDepartamentos repositoryDepartamentos)</header>
        ///     <description>Constructor que recibe las dependencias de repositorio necesarias.</description>
        ///     <precondition>Los parámetros `repositoryPersonas` y `repositoryDepartamentos` deben ser instancias válidas.</precondition>
        ///     <postcondition>Los repositorios quedan almacenados en campos privados para su uso por los métodos del caso de uso.</postcondition>
        /// </summary>
        public DefaultUseCasePersonas(IRepositoryPersonas repositoryPersonas, IRepositoryDepartamentos repositoryDepartamentos)
        {
            _repositoryPersonas = repositoryPersonas;
            _repositoryDepartamentos = repositoryDepartamentos;
        }

        /// <summary>
        ///     <header>public List&lt;PersonaConNombreDeDepartamentoDTO&gt; getListaPersonasConDepartamento()</header>
        ///     <description>Obtiene la lista de personas transformada a DTOs que incluyen el nombre de su departamento.</description>
        ///     <precondition>Los repositorios deben devolver listas válidas de personas y departamentos.</precondition>
        ///     <postcondition>Devuelve una lista de <see cref="PersonaConNombreDeDepartamentoDTO"/> con la información de cada persona y el nombre de su departamento asociado.</postcondition>
        /// </summary>
        /// <returns>Devuelve List&lt;PersonaConNombreDeDepartamentoDTO&gt; con los DTOs de personas y el nombre de su departamento.</returns>
        public List<PersonaConNombreDeDepartamentoDTO> getListaPersonasConDepartamento()
        {
            String nombreDepartamento = "";
            List<PersonaConNombreDeDepartamentoDTO> listaPersonasConNombreDepartamento = new List<PersonaConNombreDeDepartamentoDTO>();
            List<Departamento> listaDepartamentos = _repositoryDepartamentos.getListaDepartamentos().ToList();

            foreach (Persona persona in _repositoryPersonas.getListaPersonas())
            {
                nombreDepartamento = listaDepartamentos
                    .Where(departamento => departamento.id == persona.idDepartamento)
                    .First().nombre;

                listaPersonasConNombreDepartamento.Add(
                    new PersonaConNombreDeDepartamentoDTO(
                        persona.id,
                        persona.nombre,
                        persona.apellido,
                        persona.direccion,
                        persona.telefono,
                        persona.fechaNac,
                        persona.imagen,
                        nombreDepartamento
                    )
                );
            }

            return listaPersonasConNombreDepartamento;
        }

        /// <summary>
        ///     <header>public PersonaConNombreDeDepartamentoDTO GetDetallePersona(int id)</header>
        ///     <description>Obtiene los datos detallados de una persona identificada por su id, incluyendo el nombre del departamento.</description>
        ///     <precondition>El repositorio de personas debe poder buscar por id.</precondition>
        ///     <postcondition>Devuelve un DTO con los detalles de la persona o null si no existe.</postcondition>
        /// </summary>
        /// <returns>Devuelve PersonaConNombreDeDepartamentoDTO con los detalles de la persona o null si no existe.</returns>
        public PersonaConNombreDeDepartamentoDTO GetDetallePersona(int id)
        {
            Persona persona = _repositoryPersonas.getPersonaById(id);

            if (persona == null)
                return null;

            Departamento departamento = _repositoryDepartamentos.getDepartamentoById(persona.idDepartamento);

            return new PersonaConNombreDeDepartamentoDTO(
                persona.id,
                persona.nombre,
                persona.apellido,
                persona.direccion,
                persona.telefono,
                persona.fechaNac,
                persona.imagen,
                departamento.nombre
            );
        }

        /// <summary>
        ///     <header>public PersonaConListaDeDepartamentosDTO GetPersonaConListaDepartamentos(int id)</header>
        ///     <description>Construye un DTO que contiene la persona solicitada y la lista completa de departamentos.</description>
        ///     <precondition>El repositorio de personas debe devolver la persona por id; el de departamentos debe devolver la lista de departamentos.</precondition>
        ///     <postcondition>Devuelve un <see cref="PersonaConListaDeDepartamentosDTO"/> aunque la persona pueda ser null si no existe.</postcondition>
        /// </summary>
        /// <returns>Devuelve PersonaConListaDeDepartamentosDTO con la persona y la lista de departamentos.</returns>
        public PersonaConListaDeDepartamentosDTO GetPersonaConListaDepartamentos(int id)
        {
            Persona persona = _repositoryPersonas.getPersonaById(id);
            List<Departamento> departamentos = _repositoryDepartamentos.getListaDepartamentos().ToList();

            return new PersonaConListaDeDepartamentosDTO(persona, departamentos);
        }

        /// <summary>
        ///     <header>public PersonaConListaDeDepartamentosDTO GetPersonaParaCrear()</header>
        ///     <description>Prepara un DTO con una persona vacía y la lista de departamentos para la pantalla de creación.</description>
        ///     <precondition>El repositorio de departamentos debe devolver la lista de departamentos.</precondition>
        ///     <postcondition>Devuelve un <see cref="PersonaConListaDeDepartamentosDTO"/> con una persona nueva y los departamentos disponibles.</postcondition>
        /// </summary>
        /// <returns>Devuelve PersonaConListaDeDepartamentosDTO con una persona vacía y la lista de departamentos.</returns>
        public PersonaConListaDeDepartamentosDTO GetPersonaParaCrear()
        {
            Persona personaVacia = new Persona();
            List<Departamento> departamentos = _repositoryDepartamentos.getListaDepartamentos().ToList();

            return new PersonaConListaDeDepartamentosDTO(personaVacia, departamentos);
        }

        /// <summary>
        ///     <header>public int CrearPersona(Persona persona)</header>
        ///     <description>Crea una nueva persona delegando al repositorio.</description>
        ///     <precondition>El parámetro `persona` debe contener los datos necesarios para la creación.</precondition>
        ///     <postcondition>Devuelve el resultado del repositorio (por ejemplo, id creado o código de estado).</postcondition>
        /// </summary>
        /// <returns>Devuelve int con el resultado del repositorio (id o código).</returns>
        public int CrearPersona(Persona persona)
        {
            return _repositoryPersonas.crearPersona(persona);
        }

        /// <summary>
        ///     <header>public int ActualizarPersona(int id, Persona persona)</header>
        ///     <description>Actualiza los datos de una persona identificada por id.</description>
        ///     <precondition>La persona con `id` debe existir o el repositorio debe manejar la actualización de forma apropiada.</precondition>
        ///     <postcondition>Devuelve el resultado proporcionado por el repositorio de actualización.</postcondition>
        /// </summary>
        /// <returns>Devuelve int con el resultado de la operación de actualización.</returns>
        public int ActualizarPersona(int id, Persona persona)
        {
            return _repositoryPersonas.actualizarPersona(id, persona);
        }

        /// <summary>
        ///     <header>public int EliminarPersona(int id)</header>
        ///     <description>Elimina la persona con el id proporcionado.</description>
        ///     <precondition>El repositorio de personas debe soportar la eliminación por id.</precondition>
        ///     <postcondition>Devuelve el resultado de la operación de eliminación según el repositorio.</postcondition>
        /// </summary>
        /// <returns>Devuelve int con el resultado de la eliminación.</returns>
        public int EliminarPersona(int id)
        {
            return _repositoryPersonas.eliminarPersona(id);
        }

        /// <summary>
        ///     <header>public List&lt;Persona&gt; getPersonas()</header>
        ///     <description>Obtiene la lista completa de entidades Persona desde el repositorio.</description>
        ///     <precondition>El repositorio de personas debe devolver un arreglo o colección de personas.</precondition>
        ///     <postcondition>Devuelve la lista de personas como <see cref="List{Persona}"/>.</postcondition>
        /// </summary>
        /// <returns>Devuelve List&lt;Persona&gt; con todas las personas.</returns>
        public List<Persona> getPersonas()
        {
            return _repositoryPersonas.getListaPersonas().ToList();
        }

        /// <summary>
        ///     <header>public Persona getPersona(int id)</header>
        ///     <description>Recupera una entidad Persona por su id.</description>
        ///     <precondition>El repositorio debe implementar la búsqueda por id.</precondition>
        ///     <postcondition>Devuelve la instancia de <see cref="Persona"/> o null si no existe.</postcondition>
        /// </summary>
        /// <returns>Devuelve Persona si existe, o null en caso contrario.</returns>
        public Persona getPersona(int id)
        {
            return _repositoryPersonas.getPersonaById(id);
        }
    }
}
