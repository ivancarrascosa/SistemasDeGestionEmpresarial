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

        public List<Mision> getMisiones()
        {
            int horaActual = DateTime.Now.Hour;
            if (horaActual >= 8)
            {
                return _misionRepository.getMisiones();
            }
            throw new Exception("Misiones no disponibles");
        }
    }
}
