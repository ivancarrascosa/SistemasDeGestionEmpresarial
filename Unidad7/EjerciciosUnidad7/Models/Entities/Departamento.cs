namespace EjerciciosUnidad7.Models.Entities
{
    public class Departamento
    {
        #region Atributos privados
        private int _idDepartamento;
        private string _nombreDepartamento;
        #endregion
        #region Constructor
        public Departamento(int idDepartamento, string nombreDepartamento)
        {
            this._idDepartamento = idDepartamento;
            this._nombreDepartamento = nombreDepartamento;
        }
        #endregion
        #region Getters y setters
        public int idDepartamento
        {
            get { return _idDepartamento; }
            set { _idDepartamento = value; }
        }
        public string nombreDepartamento
        {
            get { return _nombreDepartamento; }
            set { _nombreDepartamento = value; }
        }
        #endregion
    }
}
