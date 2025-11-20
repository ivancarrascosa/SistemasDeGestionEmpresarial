using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositorioVacio : IRepository
    {
        public Departamento[] getListaDepartamentos()
        {
            throw new NotImplementedException();
        }

        public Persona[] getListaPersonas()
        {
            return [];
        }
    }
}
