using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    /// <summary>
    ///     <header>public class DefaultUseCaseDepartamentos : IUseCaseDepartamentos</header>
    ///     <description>Implementación por defecto de los casos de uso relacionados con Departamentos.</description>
    ///     <precondition>Se requieren repositorios válidos para departamentos y personas inyectados en el constructor.</precondition>
    ///     <postcondition>Proporciona métodos para obtener, crear, actualizar y eliminar departamentos, y obtener personas por departamento.</postcondition>
    /// </summary>
    public class DefaultUseCaseDepartamentos : IUseCaseDepartamentos
    {
        private readonly IRepositoryDepartamentos _repositoryDepartamentos;
        private readonly IRepositoryPersonas _repositoryPersonas;

        /// <summary>
        ///     <header>public DefaultUseCaseDepartamentos(IRepositoryDepartamentos repositoryDepartamentos, IRepositoryPersonas repositoryPersonas)</header>
        ///     <description>Constructor que recibe las dependencias de repositorio necesarias.</description>
        ///     <precondition>Los parámetros `repositoryDepartamentos` y `repositoryPersonas` deben ser instancias válidas.</precondition>
        ///     <postcondition>Los repositorios quedan almacenados en campos privados para su uso por los métodos del caso de uso.</postcondition>
        /// </summary>
        public DefaultUseCaseDepartamentos(IRepositoryDepartamentos repositoryDepartamentos, IRepositoryPersonas repositoryPersonas)
        {
            _repositoryDepartamentos = repositoryDepartamentos;
            _repositoryPersonas = repositoryPersonas;
        }

        public List<Departamento> GetDepartamentos()
        {
            return _repositoryDepartamentos.getListaDepartamentos().ToList();
        }

        public Departamento GetDetalleDepartamento(int id)
        {
            return _repositoryDepartamentos.getDepartamentoById(id);
        }

        public Departamento GetDepartamentoParaEditar(int id)
        {
            return _repositoryDepartamentos.getDepartamentoById(id);
        }

        public List<Persona> GetPersonasPorDepartamento(int id)
        {
            return _repositoryPersonas.getListaPersonas()
                .Where(p => p.idDepartamento == id)
                .ToList();
        }

        public int CrearDepartamento(Departamento departamento)
        {
            return (_repositoryDepartamentos.crearDepartamento(departamento));
        }

        public int ActualizarDepartamento(Departamento departamento)
        {
            return (_repositoryDepartamentos.actualizarDepartamento(departamento.id, departamento));
        }

        /// <summary>
        ///     <header>public int EliminarDepartamento(int id)</header>
        ///     <description>Elimina el departamento si no tiene personas asignadas; lanza una excepción si existen personas en el departamento.</description>
        ///     <precondition>El repositorio de personas debe proporcionar el método contarPersonadepartamento y el repositorio de departamentos debe soportar la eliminación por id.</precondition>
        ///     <postcondition>Si hay personas asignadas, se lanza InvalidOperationException. Si no, se delega la eliminación al repositorio y se devuelve su resultado.</postcondition>
        /// </summary>
        /// <returns>Devuelve int con el resultado de la operación de eliminación proporcionado por el repositorio.</returns>
        public int EliminarDepartamento(int id)
        {
            // Verificar si hay personas en este departamento
            int cantidadPersonas = _repositoryPersonas.contarPersonadepartamento(id);

            if (cantidadPersonas > 0)
            {
                throw new InvalidOperationException(
                    $"No se puede eliminar el departamento porque tiene {cantidadPersonas} persona(s) asignada(s)."
                );
            }

            return (_repositoryDepartamentos.eliminarDepartamento(id));
        }
    }
}
