using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_GCCCine.Clases;
using WCF_GCCCine.Model;

namespace WCF_GCCCine
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IPelicula
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["GCCCine"].ConnectionString;

     

        public List<Pelicula> GetPeliculas()
            {

                List<Pelicula> peliculas = new List<Pelicula>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT PeliculaID, Titulo, Genero, Duracion FROM GCC_Peliculas", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        peliculas.Add(new Pelicula
                        {
                            PeliculaID = (int)reader["PeliculaID"],
                            Titulo = reader["Titulo"].ToString(),
                            Genero = reader["Genero"].ToString(),
                            Duracion = reader["Duracion"].ToString()
                        });
                    }
                }

                return peliculas;
            }
        public Pelicula GetPelicula(int PeliculaId)
        {
            Pelicula pelicula = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PeliculaID, Titulo, Genero, Duracion FROM GCC_Peliculas WHERE PeliculaId = @PersonId", conn);
                cmd.Parameters.AddWithValue("@PersonID", PeliculaId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pelicula = new Pelicula
                    {
                        PeliculaID = (int)reader["PeliculaID"],
                        Titulo = reader["Titulo"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        Duracion = reader["Duracion"].ToString()
                    };
                }
            }
            return pelicula;
        }

        public void AddPelicula(Pelicula pelicula)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO GCC_Peliculas (Titulo, Genero, Duracion) VALUES (@Titulo, @Genero, @Duracion)", conn);
                cmd.Parameters.AddWithValue("@Titulo", pelicula.Titulo);
                cmd.Parameters.AddWithValue("@Genero", pelicula.Genero);
                cmd.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Funciones> GetFunciones()
        {
            List<Funciones> funciones = new List<Funciones>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT  gp.Titulo,
                gf.Fechafuncion,
                gf.Precio
                FROM GCC_Funciones gf 
                JOIN GCC_Peliculas gp ON gf.FuncionId = gp.PeliculaId";
                

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Funciones detail = new Funciones
                        {
                          
                            PeliculaId = (int)reader["PeliculaID"],
                            SalaId = (int)reader["SalaId"],
                            Fechafuncion = (DateTime)reader["Fechafuncion"],
                            precio = (double)reader["Precio"],
                            Pelicula = new Pelicula
                           {
                               PeliculaID = (int)reader["PeliculaID"],
                               Titulo = reader["Titulo"].ToString(),
                               Genero = reader["Genero"].ToString(),
                               Duracion = reader["Duracion"].ToString()
                           }
                            
                        };
                        funciones.Add(detail);
                    
                    }
                }
            }
            return funciones;
        }

        public void addFunciones(Funciones funciones)
        {
            throw new NotImplementedException();
        }
    }
}
/*
        public string TestConnection()
        {
            try
            {
                using (
                SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return "Connection Successful";
                }
            }
            catch (Exception ex)
            {
                return $"Connection Failed: {ex.Message}";
            }
        }
     
      
    }
}
  */

