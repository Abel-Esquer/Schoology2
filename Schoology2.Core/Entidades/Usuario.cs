using MySql.Data.MySqlClient;
using Schoology2.Core.Database;
using Schoology2.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        enum rol {
            Admin,
            Alumno,
            Profesor
        }

        public static List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM usuario;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = int.Parse(dataReader["id"].ToString());
                        usuario.Nombre = dataReader["nombre"].ToString();
                        usuario.Apellido = dataReader["apellido"].ToString();
                        usuario.Correo = dataReader["correo"].ToString();
                        usuario.Contraseña = dataReader["password"].ToString();
                        usuario.Rol = dataReader["rol"].ToString();

                        usuarios.Add(usuario);
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


    }
    
}


