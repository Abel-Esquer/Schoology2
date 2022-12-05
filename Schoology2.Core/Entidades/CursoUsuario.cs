using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Schoology2.Core.Database;
using Schoology2.Core.Entidades;


namespace Schoology2.Core.Entidades
{
    public class CursoUsuario
    {
        public int Id { get; set; }
        public Curso IdCurso { get; set; }
        public Usuario IdAlumno { get; set; }

        public static bool Aniadir(int idCurso, int idAlumno)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    cmd.CommandText = "INSERT INTO curso_usuario (idCurso, idAlumno) VALUES (@idCurso, @idAlumno)";
                    cmd.Parameters.AddWithValue("@idCurso", idCurso);
                    cmd.Parameters.AddWithValue("@idAlumno", idAlumno);

                    result = cmd.ExecuteNonQuery() == 1;    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static List<CursoUsuario> GetAll()
        {
            List<CursoUsuario> cus = new List<CursoUsuario>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM curso_usuario;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        CursoUsuario cu = new CursoUsuario();
                        cu.Id = int.Parse(dataReader["id"].ToString());

                        Curso curso = new Curso();
                        curso.Id = int.Parse(dataReader["idCurso"].ToString());
                        cu.IdCurso = curso;

                        Usuario alumno = new Usuario();
                        alumno.Id = int.Parse(dataReader["idAlumno"].ToString());
                        cu.IdAlumno = alumno;
                        cus.Add(cu);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cus;
        }

        public static List<CursoUsuario> GetById(int id)
        {
            List<CursoUsuario> cus = new List<CursoUsuario>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM curso_usuario WHERE idCurso = @idCurso;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@idCurso", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        CursoUsuario cu = new CursoUsuario();
                        cu.Id = int.Parse(dataReader["id"].ToString());

                        Curso curso = new Curso();
                        curso.Id = int.Parse(dataReader["idCurso"].ToString());
                        cu.IdCurso = curso;

                        Usuario alumno = new Usuario();
                        alumno.Id = int.Parse(dataReader["idAlumno"].ToString());
                        cu.IdAlumno = alumno;
                        cus.Add(cu);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cus;
        }

        public static List<CursoUsuario> GetAlumnos(int id)
        {
            List<CursoUsuario> cus = new List<CursoUsuario>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT c.nombre as curso, c.clave, a.id as idAlumno, a.nombre as aNombre, a.apellido as aApellido, a.correo FROM curso_usuario " +
                        "INNER JOIN curso as c ON curso_usuario.idCurso = c.id INNER JOIN usuario as a ON curso_usuario.idAlumno = a.id " +
                        "WHERE idCurso = @idCurso;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@idCurso", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        CursoUsuario cu = new CursoUsuario();

                        Curso curso = new Curso();
                        curso.Nombre = dataReader["curso"].ToString();
                        curso.Clave = dataReader["clave"].ToString();
                        cu.IdCurso = curso;

                        Usuario alumno = new Usuario();
                        alumno.Id = int.Parse(dataReader["idAlumno"].ToString());
                        alumno.Nombre = dataReader["aNombre"].ToString();
                        alumno.Apellido = dataReader["aAPellido"].ToString();
                        alumno.Correo = dataReader["correo"].ToString();
                        cu.IdAlumno = alumno;

                        cus.Add(cu);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cus;
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
                    cmd.CommandText = "DELETE FROM curso_usuario WHERE idAlumno = @id";
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
