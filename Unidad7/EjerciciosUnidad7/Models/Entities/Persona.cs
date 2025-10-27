namespace EjerciciosUnidad7.Models.Entities
{
    public class Persona
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        private string _apellido;
        private int _numDepartamento; // Aquí debo meter solo el id, no el departamento entero, es equivalente a las tablas de la base de datos

        #endregion
        #region getters y setters
        public int id { get { return _id; }}
        public string nombre {  
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public int numDepartamento
        {
            get { return _numDepartamento; }
            set { _numDepartamento = value; }
        }
        #endregion
        #region constructores
        public Persona() { }
        public Persona(int id, string nombre, string apellido, int departamento)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _numDepartamento = departamento;
        }

        #endregion
    }
}
