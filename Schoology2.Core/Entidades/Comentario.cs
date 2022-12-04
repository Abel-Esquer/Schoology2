using MySql.Data.MySqlClient;
using Schoology2.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public Usuario Alumno { get; set; }
        public DateTime FechaPublicado { get; set; }
        public DateTime FechaActualizado { get; set; }
        public Publicacion IdPublicacion { get; set; }

        public static List<Comentario> GetAll()
        {
            List<Comentario> comentarios = new List<Comentario>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM comentario;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Comentario comentario = new Comentario();
                        comentario.Id = int.Parse(dataReader["id"].ToString());
                        comentario.Contenido = dataReader["contenido"].ToString();
                        comentario.Alumno = dataReader["alumno"].ToString();
                        if{ }
                        comentario.FechaPublicado = dataReader["fechaPublicado"].ToString();
                        comentario.FechaActualizado = dataReader["fechaActualizado"].ToString();
                         = dataReader["contraseña"].ToString();
                     

                        comentarios.Add(comentario);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuarios;
        }
        public static Comentario GetById(int id)
        {
            Comentario comentario = new Comentario();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM comentario WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                       
                        comentario.Id = int.Parse(dataReader["id"].ToString());
                        comentario.Contenido = dataReader["contenido"].ToString();
                        comentario.FechaPublicado = Convert.ToDateTime(dataReader["fechaPublicado"]);
                        comentario.FechaActualizado = Convert.ToDateTime(dataReader["fechaActualizado"]);

                        Publicacion publicacion = new Publicacion();
                        publicacion.Id = int.Parse(dataReader["idPublicacion"].ToString());
                        comentario.IdPublicacion = publicacion;

                        Usuario usuario = new Usuario();

                        usuario.Id = int.Parse(dataReader["pId"].ToString());
                        comentario.Alumno.Nombre = dataReader["alumno"].ToString();
                        comentario.Alumno.Apellido = dataReader["alumno"].ToString();
                        comentario.Alumno = usuario;
                        
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comentario;

        }

        public static bool Guardar(int id, string contenido, Usuario alumno, DateTime fechaPublicado, string fechaActualizado, Publicacion idPublicacion)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    if (id == 0)
                    {
                        cmd.CommandText = "INSERT INTO comentario (contenido, alumno, idPublicacion) VALUES (@contenido, @alumno, @idPublicacion)";
                        cmd.Parameters.AddWithValue("@contenido", contenido);
                        cmd.Parameters.AddWithValue("@alumno", alumno);
                        cmd.Parameters.AddWithValue("@idPublicacion", idPublicacion);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE comentario SET contenido = @contenido, alumno = @alumno, idPublicacion = @idPublicacion WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@contenido", contenido);
                        cmd.Parameters.AddWithValue("@alumno", alumno);
                        cmd.Parameters.AddWithValue("@idPublicacion", idPublicacion);
                    }
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM comentario WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }

    
}
