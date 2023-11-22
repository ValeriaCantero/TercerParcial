using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace API_Parcial.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CuentasController : ControllerBase
    {
        private const string connectionString = ("Server=localhost;Port=5432;UserId=postgres;Password=03postgres;Database=ParcialOptativo;");
        private CuentasService servicio;

        public CuentasController()
        {
            servicio = new CuentasService(connectionString);
        }

        [HttpGet("por parámetro")]
        public IActionResult ObtenerCuentasAccion([FromQuery] int id)
        {
            var cuentas = servicio.obtenerCuentas(id);
            return Ok(cuentas);
        }

        //[HttpPost]
        //public IActionResult InsertarCuentasAccion([FromBody] Infraestructura.Modelos.CuentasModel cuentas)
        //{
        //    servicio.insertarCuenta(cuentas);
        //    return Ok("El registro se creó con éxito");
        //}

        [HttpPost("RegistrarCuenta")]
        public IActionResult RegistrarCuenta([FromBody] Modelos.CuentasModelo modelo)
        {
            servicio.insertarCuenta(
                new Infraestructura.Modelos.CuentasModel
                {
                    idCuenta = modelo.idCuenta,
                    costoMantenimiento = modelo.costoMantenimiento,
                    fechaAlta = modelo.fechaAlta,
                    promedioAcreditacion = modelo.promedioAcreditacion,
                    nroContacto = modelo.nroContacto,
                    nroCuenta = modelo.nroCuenta,
                    tipoCuenta = modelo.tipoCuenta,
                    moneda = modelo.moneda,
                    estado = modelo.estado,
                    cliente = new Infraestructura.Modelos.ClienteModel
                    {
                        idCliente = modelo.idcliente
                    }
                });
            return Ok("Los datos de persona fueron insertados correctamente");
        }

        [HttpPut]
        public IActionResult ModificarCuentaAccion([FromBody] Infraestructura.Modelos.CuentasModel cuentas)
        {
            servicio.modificarCuentas(cuentas);
            return Ok("Se modificó con éxito el registro");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCuentas(int id)
        {
            return Ok("El registro se borró correctamente");
        }
    }
}
