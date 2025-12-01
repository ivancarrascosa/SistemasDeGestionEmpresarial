using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Data.Repositories
{
    /// <summary>
    /// Implementación del repositorio para la entidad Persona, utilizando una conexión a base de datos SQL Server (presumiblemente en Azure).
    /// </summary>
    public class PersonasRepositoryAzure : IRepositoryPersonas
    {
        /// <summary>
        /// Actualiza los datos de una persona existente en la base de datos.
        /// </summary>
        /// <param name="idPersona">El identificador (ID) de la persona a actualizar.</param>
        /// <param name="persona">Objeto Persona con los nuevos datos para actualizar.</param>
        /// <returns>El número de filas afectadas (debería ser 1 si la actualización es exitosa).</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos.</exception>
        /// <remarks>
        /// **Precondición:** El ID de la persona debe existir en la tabla `Personas`. El objeto `persona` debe contener datos válidos.
        /// **Postcondición:** La fila en la tabla `Personas` con el ID especificado se actualiza con los nuevos valores de la entidad `persona`.
        /// </remarks>
        public int actualizarPersona(int idPersona, Persona persona)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = @"UPDATE Personas 
                                 SET Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, 
                                     Telefono = @Telefono, Foto = @Foto, IDDepartamento = @IDDepartamento, FechaNacimiento = @FechaNacimiento 
                                 WHERE ID = @ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", persona.nombre);
                    miComando.Parameters.AddWithValue("@Apellidos", persona.apellido);
                    miComando.Parameters.AddWithValue("@Direccion", persona.direccion);
                    miComando.Parameters.AddWithValue("@Telefono", persona.telefono);
                    miComando.Parameters.AddWithValue("@Foto", persona.imagen);
                    miComando.Parameters.AddWithValue("@IDDepartamento", persona.idDepartamento);
                    // Manejo de valores nulos para FechaNacimiento
                    miComando.Parameters.AddWithValue("@FechaNacimiento", (object)persona.fechaNac ?? DBNull.Value);
                    miComando.Parameters.AddWithValue("@ID", idPersona);

                    try
                    {
                        miConexion.Open();
                        filasAfectadas = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Inserta una nueva persona en la base de datos.
        /// </summary>
        /// <param name="personaNueva">El objeto Persona que contiene los datos de la nueva persona a crear.</param>
        /// <returns>El número de filas afectadas (debería ser 1 si la inserción es exitosa).</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos, por ejemplo, una violación de clave foránea o restricción de unicidad.</exception>
        /// <remarks>
        /// **Precondición:** El IDDepartamento debe corresponder a un departamento existente.
        /// **Postcondición:** Se añade una nueva fila a la tabla `Personas` con los datos proporcionados.
        /// </remarks>
        public int crearPersona(Persona personaNueva)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = @"INSERT INTO Personas 
                                 (Nombre, Apellidos, Direccion, Telefono, Foto, IDDepartamento, FechaNacimiento) 
                                 VALUES 
                                 (@Nombre, @Apellidos, @Direccion, @Telefono, @Foto, @IDDepartamento, @FechaNacimiento)";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", personaNueva.nombre);
                    miComando.Parameters.AddWithValue("@Apellidos", personaNueva.apellido);
                    miComando.Parameters.AddWithValue("@Direccion", personaNueva.direccion);
                    miComando.Parameters.AddWithValue("@Telefono", personaNueva.telefono);
                    miComando.Parameters.AddWithValue("@Foto", personaNueva.imagen);
                    miComando.Parameters.AddWithValue("@IDDepartamento", personaNueva.idDepartamento);
                    // Manejo de valores nulos para FechaNacimiento
                    miComando.Parameters.AddWithValue("@FechaNacimiento", (object)personaNueva.fechaNac ?? DBNull.Value);

                    try
                    {
                        miConexion.Open();
                        filasAfectadas = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Elimina una persona de la base de datos por su ID.
        /// </summary>
        /// <param name="idPersona">El identificador (ID) de la persona a eliminar.</param>
        /// <returns>El número de filas afectadas (1 si se eliminó, 0 si no se encontró).</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos, por ejemplo, una violación de clave foránea.</exception>
        /// <remarks>
        /// **Precondición:** El ID de la persona debe existir en la tabla `Personas`.
        /// **Postcondición:** La fila correspondiente a la `idPersona` se elimina de la tabla `Personas`.
        /// </remarks>
        public int eliminarPersona(int idPersona)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "DELETE FROM Personas WHERE ID = @ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idPersona);

                    try
                    {
                        miConexion.Open();
                        filasAfectadas = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Obtiene una persona de la base de datos por su ID.
        /// </summary>
        /// <param name="idPersona">El identificador (ID) de la persona a buscar.</param>
        /// <returns>Un objeto <see cref="Persona"/> si se encuentra, o <c>null</c> si no existe.</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos.</exception>
        /// <remarks>
        /// **Postcondición:** Se devuelve el objeto <see cref="Persona"/> con el ID correspondiente o <c>null</c>.
        /// </remarks>
        public Persona getPersonaById(int idPersona)
        {
            Persona oPersona = null;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "SELECT * FROM Personas WHERE ID = @ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idPersona);

                    try
                    {
                        miConexion.Open();
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.Read())
                            {
                                oPersona = new Persona(
                                    (int)miLector["ID"],
                                    (string)miLector["Nombre"],
                                    (string)miLector["Apellidos"],
                                    (string)miLector["Direccion"],
                                    (string)miLector["Telefono"],
                                    (string)miLector["Foto"],
                                    (int)miLector["IDDepartamento"]
                                );

                                if (miLector["FechaNacimiento"] != DBNull.Value)
                                {
                                    oPersona.fechaNac = (DateTime)miLector["FechaNacimiento"];
                                }
                            }
                        }
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return oPersona;
        }

        /// <summary>
        /// Cuenta el número de personas que pertenecen a un departamento específico.
        /// </summary>
        /// <param name="idDepartamento">El identificador (ID) del departamento a contar.</param>
        /// <returns>El número de personas en el departamento especificado.</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos.</exception>
        /// <remarks>
        /// **Postcondición:** Se devuelve un entero que representa el número total de personas asociadas con `idDepartamento`.
        /// </remarks>
        public int contarPersonadepartamento(int idDepartamento)
        {
            int contador = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "SELECT COUNT(*) FROM Personas WHERE IDDepartamento = @IDDepartamento";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@IDDepartamento", idDepartamento);

                    try
                    {
                        miConexion.Open();
                        // ExecuteScalar se usa para consultas que devuelven un único valor
                        contador = (int)miComando.ExecuteScalar();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return contador;
        }

        /// <summary>
        /// Obtiene un listado de todas las personas de la base de datos.
        /// </summary>
        /// <returns>Un array de objetos <see cref="Persona"/>.</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos.</exception>
        /// <remarks>
        /// **Postcondición:** Se devuelve un array con todas las filas de la tabla `Personas` mapeadas a objetos <see cref="Persona"/>.
        /// </remarks>
        public Persona[] getListaPersonas()
        {
            SqlConnection miConexion = new SqlConnection();
            List<Persona> listadoPersonas = new List<Persona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            Persona oPersona;

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new Persona(
                            (int)miLector["ID"],
                            (string)miLector["Nombre"],
                            (string)miLector["Apellidos"],
                            (string)miLector["Direccion"],
                            (string)miLector["Telefono"],
                            (string)miLector["Foto"],
                            (int)miLector["IDDepartamento"]
                        );

                        if (miLector["FechaNacimiento"] != DBNull.Value)
                        {
                            oPersona.fechaNac = (DateTime)miLector["FechaNacimiento"];
                        }

                        listadoPersonas.Add(oPersona);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoPersonas.ToArray();
        }
    }
}