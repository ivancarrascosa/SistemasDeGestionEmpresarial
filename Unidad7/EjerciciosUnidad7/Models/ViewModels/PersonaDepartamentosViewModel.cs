using EjerciciosUnidad7.Models.Entities;
using EjerciciosUnidad7.Models.Entities.DAL;

namespace EjerciciosUnidad7.Models.ViewModels
{
    public class PersonaDepartamentosViewModel
    {
        private Persona _persona;
        private ListadoDepartamentos _listadoDepartamentos;
        public PersonaDepartamentosViewModel(Persona persona, ListadoDepartamentos listadoDepartamentos)
        {
            _persona = persona;
            _listadoDepartamentos = listadoDepartamentos;
        }
        public Persona persona
        {
            get { return _persona; }
        }
        public ListadoDepartamentos listadoDepartamentos
        {
            get { return _listadoDepartamentos; }
        }

    }
}
