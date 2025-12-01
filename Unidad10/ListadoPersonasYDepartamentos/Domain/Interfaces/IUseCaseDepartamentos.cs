using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUseCaseDepartamentos
    {
        List<Departamento> GetDepartamentos();
        Departamento GetDetalleDepartamento(int id);
        Departamento GetDepartamentoParaEditar(int id);
        List<Persona> GetPersonasPorDepartamento(int id);
        int CrearDepartamento(Departamento departamento);
        int ActualizarDepartamento(Departamento departamento);
        int EliminarDepartamento(int id);
    }
}
