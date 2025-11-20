using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PersonasRepositorio : IRepository
    {
        public Departamento[] getListaDepartamentos()
        {
            throw new NotImplementedException();
        }

        public Persona[] getListaPersonas()
        {
            return [
                new Persona(1, "Elena", "Alcalde García"),
                new Persona(2, "Luis", "Cerrato Vela"),
                new Persona(3, "María", "Díaz Fernández"),
                new Persona(4, "Javier", "Gómez Pérez"),
                new Persona(5, "Laura", "Martínez López"),
                new Persona(6, "Carlos", "Sánchez Ruiz"),
                new Persona(7, "Ana", "Romero Torres"),
                new Persona(8, "Miguel", "Navarro Díaz"),
                new Persona(9, "Lucía", "Hernández Rojas"),
                new Persona(10, "David", "Castro Medina"),
                new Persona(11, "Sofía", "Moreno García"),
                new Persona(12, "Andrés", "López Salazar"),
                new Persona(13, "Valeria", "Núñez Cabrera"),
                new Persona(14, "Tomás", "Blanco Romero"),
                new Persona(15, "Paula", "Paredes León"),
                new Persona(16, "Ignacio", "Ruiz Herrera"),
                new Persona(17, "Daniela", "Santos Molina"),
                new Persona(18, "Hugo", "Delgado Cruz"),
                new Persona(19, "Martina", "Campos Suárez"),
                new Persona(20, "Emilio", "Fernández Bravo"),
                new Persona(21, "Julia", "Marín Ortega"),
                new Persona(22, "Rubén", "Peña Solís"),
                new Persona(23, "Alicia", "Cano Fuentes"),
                new Persona(24, "Santiago", "Giménez Rivas"),
                new Persona(25, "Clara", "Aguilar Vega"),
                new Persona(26, "Joaquín", "Ortiz Méndez"),
                new Persona(27, "Natalia", "Carrasco Nieto"),
                new Persona(28, "Marco", "Gallardo Rubio"),
                new Persona(29, "Noa", "Serrano Cordero"),
                new Persona(30, "Álvaro", "Esteban Domínguez"),
                new Persona(31, "Irene", "Ramos Gil"),
                new Persona(32, "Mario", "Silva Arias"),
                new Persona(33, "Lola", "Mora Lozano"),
                new Persona(34, "Bruno", "Vargas Dávila"),
                new Persona(35, "Adriana", "Reyes Pascual"),
                new Persona(36, "Cristian", "Cuenca Pons"),
                new Persona(37, "Eva", "Bueno Peralta"),
                new Persona(38, "Samuel", "Roldán Bernal"),
                new Persona(39, "Gabriela", "Camacho Salas"),
                new Persona(40, "Esteban", "Benítez Torres"),
                new Persona(41, "Inés", "Soto Calderón"),
                new Persona(42, "Fernando", "Iglesias Rosas"),
                new Persona(43, "Victoria", "Aranda Lázaro"),
                new Persona(44, "Rodrigo", "Gallego Morillo"),
                new Persona(45, "Carmen", "Solano Ferrer"),
                new Persona(46, "Gonzalo", "Alonso Vidal"),
                new Persona(47, "Elisa", "Martos Casado"),
                new Persona(48, "Óscar", "Del Valle Cuesta"),
                new Persona(49, "Nerea", "Garrido Lozano"),
                new Persona(50, "Lucas", "Castaño Arenas"),
                new Persona(51, "Ángela", "Prado Guzmán"),
                new Persona(52, "Mateo", "Redondo Pastor"),
                new Persona(53, "Claudia", "Román Sevilla"),
                new Persona(54, "Alonso", "Del Río Salmerón"),
                new Persona(55, "Beatriz", "Navarrete Galán"),
                new Persona(56, "Julián", "Villar Paredes"),
                new Persona(57, "Lorena", "Sáez Aguado"),
                new Persona(58, "Iván", "Crespo Hidalgo"),
                new Persona(59, "Teresa", "Vallejo Redondo"),
                new Persona(60, "Marcos", "Cabrera Montoro"),
                ];
        }
    }
}
