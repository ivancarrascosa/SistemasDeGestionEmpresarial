using EjerciciosUnidad7.Models.Entities;
using EjerciciosUnidad7.Models.Entities.DAL;

namespace EjerciciosUnidad7.Models
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
            set { _persona = value; }
        }
        public ListadoDepartamentos listadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set { _listadoDepartamentos = value; }
        }

    }
}
