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
    public class ListadoMisionesUseCase : IUseCase
    {
        private readonly IRepository _misionRepository;
        public ListadoMisionesUseCase(IRepository misionRepository)
        {
            _misionRepository = misionRepository;
        }
        public Mision getMision(int id)
        {
            List<Mision> listadoMisiones = _misionRepository.getMisiones();
            bool encontrado = false;
            int cont = 0;
            while (!encontrado && cont < listadoMisiones.Count)
            {
                if (listadoMisiones[cont].Id == id)
                {
                    return listadoMisiones[cont];
                }
                cont++;
            }
            throw new Exception("Mision no encontrada");
        }
        /// <summary>
        /// Funcion que devuelve la lista de misiones a las horas disponibles
        /// </summary>
        /// <returns>Lista de misiones</returns>
        /// <exception cref="Exception">Lanza excepcion si las misiones no están disponibles a esa hora.</exception>
        public List<Mision> getMisiones()
        {
            int horaActual = DateTime.Now.Hour;
            if (horaActual >= 8)
            {
                return _misionRepository.getMisiones();
            } else
            {
                throw new Exception("A esta hora no tienes permiso para ver las misiones, descansa.");
            }
                
        }
    }
}
