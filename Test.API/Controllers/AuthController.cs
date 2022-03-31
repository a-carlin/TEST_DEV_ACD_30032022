using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.API.Modelos;
using Test.Data.Interfaces;
using Test.Models;
using Test.Models.Excepciones;

namespace Test.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _servicio;
        public AuthController(IAuth servicio)
        {
            _servicio = servicio;

        }
        [Route("api/Auth")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpStatusCodeException((int)ErroresGenericos.NullRequestError.HttpCode);
            }
            if (usuario.Correo == null || usuario.Correo.Equals("") ||
                usuario.Contrasena == null || usuario.Contrasena.Equals(""))
            {
                throw new HttpStatusCodeException((int)ErroresGenericos.NullRequestError.HttpCode);
            }
            var usuarioModel = await _servicio.Login(usuario);

            return Ok(usuarioModel);
        }
    }
}
