namespace EjerciciosUnidad7.Models.Entities
{
    public class Persona
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        private string _apellido;
        private Departamento _departamento;

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

        public Departamento departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }
        #endregion
        #region constructores
        public Persona() { }
        public Persona(int id, string nombre, string apellido, Departamento departamento)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _departamento = departamento;
        }

        #endregion
    }
}
