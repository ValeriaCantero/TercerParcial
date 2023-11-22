using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace API_Parcial.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private const string connectionString = ("Server=localhost;Port=5432;UserId=postgres;Password=03postgres;Database=ParcialOptativo;");
        private UsuarioService servicio;

        public UsuarioController()
        {
            servicio = new UsuarioService(connectionString);
        }

        [HttpGet("por parámetro")]
        public IActionResult ObtenerUsuarioNombre([FromQuery] string username)
        {
            var usuario = servicio.obtenerUsuarioNombre(username);
            return Ok(usuario);
        }

        [HttpPost("RegistrarUsuario")]
        public IActionResult RegistrarUsuario([FromBody]Modelos.UsuarioModelo modelo)
        {
            servicio.insertarUsuario(
                new Infraestructura.Modelos.UsuarioModel
                {
                    idUsuario = modelo.idUsuario,
                    nombre_usuario = modelo.nombre_usuario,
                    nivel = modelo.nivel,
                    estado = modelo.estado,
                    idPersona = modelo.idPersona,
                    persona = new Infraestructura.Modelos.PersonaModel
                    {
                        idPersona = modelo.idPersona
                    }
                });
            return Ok("Los datos de persona fueron insertados correctamente");
        }

        [HttpPut]
        public IActionResult ModificarUsuarioAccion([FromBody] Infraestructura.Modelos.UsuarioModel usuario)
        {
            servicio.modificarUsuario(usuario);
            return Ok("El registro se modificó con éxito");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            return Ok("El registro se borró correctamente");
        }
    }
}
