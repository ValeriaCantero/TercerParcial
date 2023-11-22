using Infraestructura.Modelos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Servicios.ContactosService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Parcial.Controllers
{
    [Route("[Controller]")]
    public class AuthController : Controller
    {
        private const string connectionString = ("Server=localhost;Port=5432;UserId=postgres;Password=03postgres;Database=ParcialOptativo;");
        private readonly IConfiguration _configuracion;
        private UsuarioService servicio;

        public AuthController (IConfiguration configuration)
        {
            _configuracion = configuration;
            servicio = new UsuarioService(connectionString);
        }

        [HttpPost("Login")]
        public IActionResult Post([FromBody] LoginModel login)
        {
            var userIsValid = validUser(login);
            if (!userIsValid)
            {
                return Unauthorized();
            }
            var token = GenerateJWT(login.UserName);
            return Ok(token);
        }

        private object GenerateJWT(string userName)
        {
           
           var segurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion["Jwt:Key"]));
           var credentials = new SigningCredentials (segurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Name, "Julia"),
                new Claim(JwtRegisteredClaimNames.FamilyName, " Colman"),
                new Claim(JwtRegisteredClaimNames.Email, "juliacolman@gmail.com"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuracion["Jwt:Issuer"],
                audience: _configuracion["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(320),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


                
                    
            //  return login.UserName == "admin" && login.Password == 321";

       

        private bool validUser(LoginModel login)
        {

            var usuario = servicio.obtenerUsuarioNombre(login.UserName);
            if (usuario.contrasena == login.Password)
            {
                return true;
            }
            return false;
         

        }

    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
