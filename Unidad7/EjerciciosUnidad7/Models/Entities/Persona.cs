namespace EjerciciosUnidad7.Models.Entities
{
    public class Persona
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        private string _apellido;

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
        #endregion
        #region constructores
        public Persona() { }
        public Persona(int id, string nombre, string apellido)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
        }

        #endregion
    }
}
