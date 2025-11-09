using Domain.Entities;

namespace UI.Models
{
    public class IndexVM
    {
        private List<Mision> _listadoDeMisiones { get; }

        private Mision _misionSeleccionada { get; }

        public IndexVM (List<Mision> listadoMisiones, Mision misionSeleccionada) {
            _listadoDeMisiones = listadoMisiones;
            _misionSeleccionada = misionSeleccionada;
        }

        public List<Mision> listadoDeMisiones
        {
            get { return _listadoDeMisiones;}
        }

        public Mision misionSeleccionada
        {
            get { return _misionSeleccionada; }
        }
    }
}
