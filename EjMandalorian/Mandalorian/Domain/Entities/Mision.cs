using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Mision
    {
        #region atributos
        private int _id { get; }
        private string _nombre { get; set; }
        private string _descripcion { get; set; }
        private int _recompensa { get; set; }
        #endregion
        public Mision(int id, string nombre, string descripcion, int recompensa)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _recompensa = recompensa;
        }
        #region Propiedades públicas (getters y setters)
        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int Recompensa
        {
            get { return _recompensa; }
            set { _recompensa = value; }
        }
        #endregion


    }
}

