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
                        oPersona = new Persona((int)miLector["ID"], (string)miLector["Nombre"], (string)miLector["Apellidos"],
                            (string)miLector["Direccion"], (string)miLector["Telefono"], (string)miLector["Foto"], (int)miLector["IDDepartamento"]);

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
