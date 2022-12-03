﻿using MySql.Data.MySqlClient;
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
                        usuario.Contraseña = dataReader["contraseña"].ToString();
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
       
        //Agregar y Editar
        public static bool Guardar (int id, string nombre, string correo, string apellido, string contraseña, string rol)
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
                        cmd.CommandText = "INSERT INTO usuario (nombre, apellido, correo, contraseña, rol) VALUES (@nombre, @apellido, @correo, @contraseña, @rol";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);
                        cmd.Parameters.AddWithValue("@rol", rol);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE usuario SET nombre = @nombre, apellido = @apellido, correo = @correo, contraseña = @contraseña, rol = @rol WHERE id = @id" +
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);
                        cmd.Parameters.AddWithValue("@rol", rol);
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
            Usuario usuario = new Usuario();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {

                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM usuario WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Close();
                    conexion.CloseConnection();
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return result;
        }

        public static Usuario GetById(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM usuario WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        usuario.Id = int.Parse(dataReader["id"].ToString());
                        usuario.Nombre = dataReader["nombre"].ToString();
                        usuario.Apellido = dataReader["apellido"].ToString();
                        usuario.Correo = dataReader["correo"].ToString();
                        usuario.Contraseña = dataReader["contraseña"].ToString();
                        usuario.Rol = dataReader["rol"].ToString();
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
        }
    }
    
}


