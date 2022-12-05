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


        public static bool Aniadir(int id, int idCurso, int idAlumno)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    cmd.CommandText = "INSERT INTO curso_usuario (idCurso idAlumno) VALUES (@idCurso, @idAlumno)";
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
    }
}
