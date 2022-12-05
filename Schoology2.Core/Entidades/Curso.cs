using MySql.Data.MySqlClient;
using Schoology2.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public Usuario Profesor { get; set; }

        public static List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT c.id, c.nombre as curso, c.clave as clave, u.nombre as pNombre, u.apellido as pApellido, " +
                        "u.correo as correo FROM curso as c INNER JOIN usuario as u ON c.idProfesor = u.id;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Curso curso = new Curso();
                        curso.Id = int.Parse(dataReader["id"].ToString());
                        curso.Nombre = dataReader["curso"].ToString();
                        curso.Clave = dataReader["clave"].ToString();

                        Usuario usuario = new Usuario();
                        usuario.Nombre = dataReader["pNombre"].ToString();
                        usuario.Apellido = dataReader["pApellido"].ToString();
                        usuario.Correo = dataReader["correo"].ToString();

                        curso.Profesor = usuario;
                        cursos.Add(curso);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cursos;
        }

        public static bool Guardar(int id, string nombre, string clave, int idProfesor) { 
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    if (id == 0)
                    {
                        cmd.CommandText = "INSERT INTO curso (nombre, clave, idProfesor) VALUES (@nombre, @clave, @idProfesor)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@clave", clave);
                        cmd.Parameters.AddWithValue("@idProfesor", idProfesor);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE curso SET nombre = @nombre, clave = @clave, idProfesor = @idProfesor WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@clave", clave);
                        cmd.Parameters.AddWithValue("@idProfesor", idProfesor);
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
                    cmd.CommandText = "DELETE FROM curso WHERE id = @id";
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

        public static Curso GetById(int id)
        {
            Curso curso = new Curso();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT c.id, c.nombre as curso, c.clave as clave, u.nombre as pNombre, u.apellido as pApellido, " +
                        "u.correo as correo FROM curso as c INNER JOIN usuario as u ON c.idProfesor = u.id WHERE c.id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        curso.Id = int.Parse(dataReader["id"].ToString());
                        curso.Nombre = dataReader["curso"].ToString();
                        curso.Clave = dataReader["clave"].ToString();

                        Usuario usuario = new Usuario();
                        usuario.Nombre = dataReader["pNombre"].ToString();
                        usuario.Apellido = dataReader["pApellido"].ToString();
                        usuario.Correo = dataReader["correo"].ToString();

                        curso.Profesor = usuario;
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return curso;
        }
    }
}
