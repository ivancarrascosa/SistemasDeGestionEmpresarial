using Data.Database;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    /// <summary>
    /// Implementación del repositorio para la entidad Departamento, utilizando una conexión a base de datos SQL Server (presumiblemente en Azure).
    /// Implementa la interfaz <see cref="IRepositoryDepartamentos"/>.
    /// </summary>
    public class DepartamentosRepositoryAzure : IRepositoryDepartamentos
    {
        /// <summary>
        /// Actualiza el nombre de un departamento existente en la base de datos.
        /// </summary>
        /// <param name="idDepartamento">El identificador (ID) del departamento a actualizar.</param>
        /// <param name="departamento">Objeto Departamento con el nuevo nombre para la actualización.</param>
        /// <returns>El número de filas afectadas (debería ser 1 si la actualización es exitosa).</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos.</exception>
        /// <remarks>
        /// **Precondición:** El ID del departamento debe existir en la tabla `Departamentos`.
        /// **Postcondición:** La fila en la tabla `Departamentos` con el ID especificado se actualiza con el nuevo nombre.
        /// </remarks>
        public int actualizarDepartamento(int idDepartamento, Departamento departamento)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "UPDATE Departamentos SET Nombre = @Nombre WHERE ID = @ID";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", departamento.nombre);
                    miComando.Parameters.AddWithValue("@ID", idDepartamento);

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
        /// Inserta un nuevo departamento en la base de datos.
        /// </summary>
        /// <param name="departamentoNuevo">El objeto Departamento que contiene el nombre del nuevo departamento a crear.</param>
        /// <returns>El número de filas afectadas (debería ser 1 si la inserción es exitosa).</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos, por ejemplo, una violación de unicidad.</exception>
        /// <remarks>
        /// **Postcondición:** Se añade una nueva fila a la tabla `Departamentos` con el nombre proporcionado y se genera un nuevo ID.
        /// </remarks>
        public int crearDepartamento(Departamento departamentoNuevo)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", departamentoNuevo.nombre);

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
        /// Elimina un departamento de la base de datos por su ID.
        /// </summary>
        /// <param name="idDepartamento">El identificador (ID) del departamento a eliminar.</param>
        /// <returns>El número de filas afectadas (1 si se eliminó, 0 si no se encontró).</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos, especialmente si hay registros de personas vinculados (violación de Foreign Key).</exception>
        /// <remarks>
        /// **Precondición:** El ID del departamento debe existir y **no** debe tener personas asociadas a él (dependiendo de la configuración de la clave foránea).
        /// **Postcondición:** La fila correspondiente a la `idDepartamento` se elimina de la tabla `Departamentos`.
        /// </remarks>
        public int eliminarDepartamento(int idDepartamento)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "DELETE FROM Departamentos WHERE ID = @ID";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idDepartamento);

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
        /// Obtiene un departamento de la base de datos por su ID.
        /// </summary>
        /// <param name="idDepartamento">El identificador (ID) del departamento a buscar.</param>
        /// <returns>Un objeto <see cref="Departamento"/> si se encuentra, o <c>null</c> si no existe.</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos.</exception>
        /// <remarks>
        /// **Postcondición:** Se devuelve el objeto <see cref="Departamento"/> con el ID correspondiente o <c>null</c>.
        /// </remarks>
        public Departamento getDepartamentoById(int idDepartamento)
        {
            Departamento oDepartamento = null;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "SELECT * FROM Departamentos WHERE ID = @ID";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idDepartamento);

                    try
                    {
                        miConexion.Open();
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.Read())
                            {
                                oDepartamento = new Departamento((int)miLector["ID"], (string)miLector["Nombre"]);
                            }
                        }
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return oDepartamento;
        }

        /// <summary>
        /// Obtiene un listado de todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>Un array de objetos <see cref="Departamento"/>.</returns>
        /// <exception cref="SqlException">Se lanza si ocurre un error durante la operación de base de datos.</exception>
        /// <remarks>
        /// **Postcondición:** Se devuelve un array con todas las filas de la tabla `Departamentos` mapeadas a objetos <see cref="Departamento"/>. Si no hay departamentos, devuelve un array vacío.
        /// </remarks>
        public Departamento[] getListaDepartamentos()
        {
            SqlConnection miConexion = new SqlConnection();
            List<Departamento> listadoDepartamentos = new List<Departamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            Departamento oDepartamento;

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new Departamento((int)miLector["ID"], (string)miLector["Nombre"]);

                        listadoDepartamentos.Add(oDepartamento);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoDepartamentos.ToArray();
        }
    }
}