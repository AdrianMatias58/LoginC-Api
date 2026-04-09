using LoginAPIC_.DTO;
using LoginAPIC_.Servicio;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
namespace LoginAPIC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserServ _servUser;

        public UserController(UserServ srv)
        {
            _servUser = srv;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO.LoginDto datos)
        {
            if (datos == null) return BadRequest("Datos de login inválidos.");
            var resultado = await _servUser.login(datos);
            if (resultado == null)
            {
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos" });
            }
            return Ok(resultado);
        }

        [HttpPost("Registro")]
        public async Task<IActionResult> Registro([FromBody] UserDTO.RegistroDto datos)
        {
            if (datos == null) return BadRequest("Datos de registro inválidos.");
            var resultado = await _servUser.Regitro(datos);
            if (resultado == null)
            {
                return BadRequest(new { mensaje = "El usuario ya se encuentra registrado" });
            }
            return Ok(resultado);
        }
    }
}
