using EjerciciosUnidad7.Models.Entities;
using EjerciciosUnidad7.Models.Entities.DAL;

namespace EjerciciosUnidad7.Models.ViewModels
{
    public class PersonaDepartamentosViewModel
    {
        private Persona _persona;
        private List<Departamento> _listadoDepartamentos;
        public PersonaDepartamentosViewModel()
        {
            ListadoPersonas listadoPersonas = new ListadoPersonas();
            Random random = new Random();
            int numero = random.Next(0, listadoPersonas.lista.Count() - 1);
            _persona = listadoPersonas.lista[numero];
            _listadoDepartamentos = new ListadoDepartamentos().lista;
        }
        public Persona persona
        {
            get { return _persona; }
        }
        public List<Departamento> listadoDepartamentos
        {
            get { return _listadoDepartamentos; }
        }

    }
}
