﻿using Infraestructura.Conexiones;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class UsuarioDatos
    {
        private ConexionDB conexion;

        public UsuarioDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        //metodo para insertar datos en la base de datos
        public void insertarUsuario(UsuarioModel usuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO usuario(idUsuario, idPersona, nombre_usuario,nivel, estado)" +
                                                "VALUES(@idUsuario, @idPersona, @nombre_usuario,@nivel, @estado, @contrasena", conn);
            comando.Parameters.AddWithValue("idPersona", usuario.idPersona);
            comando.Parameters.AddWithValue("nombre_usuario", usuario.nombre_usuario);
            comando.Parameters.AddWithValue("estado", usuario.estado);
            comando.Parameters.AddWithValue("nivel", usuario.nivel);
            comando.Parameters.AddWithValue("idUsuario", usuario.idUsuario);
            comando.Parameters.AddWithValue("contrasena", usuario.contrasena);

            comando.ExecuteNonQuery();
        }
        // obtiene la cliente por parametro
        public UsuarioModel obtenerUsuarioNombre(string  username)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * from usuario where nombre_usuario = {username}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new UsuarioModel
                {
                    idUsuario = reader.GetInt32("idUsuario"),
                    idPersona = reader.GetInt32("idPersona"),
                    nombre_usuario = reader.GetString("nombre_usuario"),
                    nivel = reader.GetString("nivel"),
                    estado = reader.GetString("estado"),
                    contrasena= reader.GetString("contrasena"),
                    persona = new PersonaModel
                    {
                        idPersona = reader.GetInt32("idPersona"),
                        nombre = reader.GetString("nombre"),
                        apellido = reader.GetString("apellido"),
                        nroDocumento = reader.GetString("nro_Documento"),
                        direccion = reader.GetString("direccion"),
                        email = reader.GetString("email"),
                        celular = reader.GetString("celular"),
                        estado = reader.GetString("estado"),
                    }
                };
            }
            return null;
        }

        public List<UsuarioModel> obtenerLosUsuarios()
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"SELECT p.*, u.* " +
                                                   $"FROM persona p " +
                                                   $"INNER JOIN usuarios u ON p.idPersona = u.idPersona ", conn);
            List<UsuarioModel> usuarios = new List<UsuarioModel>();

            using var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                usuarios.Add(new UsuarioModel()
                {
                    idUsuario = reader.GetInt32("idUsuario"),
                    nombre_usuario = reader.GetString("nombre_usuario"),
                    contrasena = reader.GetString("contrasena"),
                    nivel = reader.GetString("nivel"),
                    estado = reader.GetString("estado"),
                    persona = new PersonaModel()
                    {
                        idPersona = reader.GetInt32("idPersona"),
                        nombre = reader.GetString("nombre"),
                        apellido = reader.GetString("apellido"),
                        nroDocumento = reader.GetString("nro_Documento"),
                        direccion = reader.GetString("direccion"),
                        email = reader.GetString("email"),
                        celular = reader.GetString("celular"),
                        estado = reader.GetString("estado"),
                    }
                });
            }

            return usuarios;
        }

        public UsuarioModel EliminarUsuarioPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM usuario WHERE idUsuario= {id}", conn);
            using var reader = comando.ExecuteReader();
            return null;
        }

        //modifica los datos en la base de datos
        public void modificarUsuario(UsuarioModel usuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE usuario SET nombre_usuario = '{usuario.nombre_usuario}', " +
                                                          $"nivel = '{usuario.nivel}', " +
                                                          $"estado = '{usuario.estado}' " +
                                                           $"idPersona = '{usuario.idPersona}', " +
                                                           $"contrasena = '{usuario.contrasena}, " +

                                                $" WHERE idCliente = {usuario.idUsuario}", conn);

            comando.ExecuteNonQuery();
        }
    }
}
