using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class UsuarioModel
    {
        public int idUsuario { get; set; }
        public int idPersona { get; set; }
        public string nombre_usuario { get; set; }
        public string contraseña { get; set; }
        public string nivel { get; set; }
        public string estado { get; set; } 
        public string contrasena { get; set; }

        public PersonaModel persona { get; set; }
    }
}
