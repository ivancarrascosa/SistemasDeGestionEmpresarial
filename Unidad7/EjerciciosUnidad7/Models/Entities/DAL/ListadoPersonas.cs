namespace EjerciciosUnidad7.Models.Entities.DAL
{
    public class ListadoPersonas
    {
        private List<Persona> _lista = [
            new Persona(1, "Juan", "Pérez", new Departamento(1, "Recursos Humanos")),
            new Persona(2, "María", "González", new Departamento(2, "Finanzas")),
            new Persona(3, "Luis", "Martínez", new Departamento(3, "Marketing")),
            new Persona(4, "Ana", "López", new Departamento(4, "Tecnología")),
            new Persona(5, "Carlos", "Ramírez", new Departamento(5, "Ventas")),
            new Persona(6, "Laura", "Díaz", new Departamento(6, "Logística")),
            ];
        
        public ListadoPersonas()
        {
        }

        public List<Persona> lista
        {
        get { return _lista; }
        }

    }
}
