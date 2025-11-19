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
    public class PersonasRepositoryAzure : IRepository
    {
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

                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new Persona((int)miLector["ID"], (string)miLector["Nombre"], (string)miLector["Apellidos"]
                            oPersona.direccion = (string)miLector["Direccion"], oPersona.telefono = (string)miLector["Telefono"]);

                        oPersona.id = (int)miLector["ID"];
                        oPersona.nombre = (string)miLector["Nombre"];
                        oPersona.apellido = (string)miLector["Apellidos"];

                        if (miLector["FechaNacimiento"] != DBNull.Value)
                        {
                            oPersona.fechaNac = (DateTime)miLector["FechaNacimiento"];
                        }

                        oPersona.direccion = (string)miLector["Direccion"];
                        oPersona.telefono = (string)miLector["Telefono"];

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
