namespace EjerciciosUnidad7.Models.Entities.DAL
{
    public class ListadoPersonas
    {
        private List<Persona> _lista = [
            new Persona(1, "Juan", "Pérez", 1),
            new Persona(2, "María", "González", 2),
            new Persona(3, "Luis", "Martínez", 3),
            new Persona(4, "Ana", "López", 4),
            new Persona(5, "Carlos", "Ramírez", 5),
            new Persona(6, "Laura", "Díaz", 6),
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
