using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosService
{
    public class UsuarioService
    {
        UsuarioDatos usuarioDatos;

        public UsuarioService(string cadenaConexion)
        {
            usuarioDatos = new UsuarioDatos(cadenaConexion);
        }

        public void insertarUsuario(UsuarioModel usuario)
        {
            validarDatos(usuario);
            usuarioDatos.insertarUsuario(usuario);
        }

        //public UsuarioModel obtenerUsuarioPorId(int id)
        //{
        //    return usuarioDatos.obtenerUsuarioPorId(id);
        //}

        public UsuarioModel obtenerUsuarioNombre(string username)
        {
            return usuarioDatos.obtenerUsuarioNombre(username);
        }
        public void modificarUsuario(UsuarioModel usuario)
        {
            validarDatos(usuario);
            usuarioDatos.modificarUsuario(usuario);
        }

        public UsuarioModel EliminarUsuario(int id)
        {
            return usuarioDatos.EliminarUsuarioPorId(id);
        }

       private void validarDatos(UsuarioModel usuario)
        {

            if (usuario.estado.Trim().Length < 2)
            {
                throw new Exception("El campo es requerido");
            }

        }
       
    }
}