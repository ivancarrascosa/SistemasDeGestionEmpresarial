namespace EjerciciosUnidad7.Models.Entities.DAL
{
    public class ListadoDepartamentos
    {
        private List<Departamento> _lista = new List<Departamento>
        {
            new Departamento(1, "Recursos Humanos"),
            new Departamento(2, "Finanzas"),
            new Departamento(3, "Marketing"),
            new Departamento(4, "Tecnología"),
            new Departamento(5, "Ventas"),
            new Departamento(6, "Logística"),
        };
        public ListadoDepartamentos()
        {
        }
        public List<Departamento> lista
        {
            get { return _lista; }
        }
    }
}
