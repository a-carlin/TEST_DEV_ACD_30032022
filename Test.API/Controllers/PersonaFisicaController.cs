using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Modelos;
using Test.Data.Interfaces;
using Test.Models;
using Test.Models.Excepciones;

namespace Test.API.Controllers
{
    [ApiController]
    public class PersonasFisicasController : ControllerBase
    {
        private readonly IPersonaFisica _service;
        public PersonasFisicasController(IPersonaFisica service)
        {
            _service = service;
        }
        [Route("/api")]
        [HttpGet]
        public IActionResult Index()
        {
            var content = "<b>API Started";
            return new ContentResult() { Content = content, ContentType = "text/html" };
        }

        [Route("api/PersonasFisicas")]
        [HttpGet]
        public async Task<IActionResult> ObtenerPersonasFisicas()
        {
            var dbPersonasFisicas = (await _service.ObtenerPersonasFisicas()).ToList();

            if (dbPersonasFisicas == null)
            {
                //_logger.LogError(Constants.RESPONSE, Constants.API_NAME, "GET", "NULL");
               throw new HttpStatusCodeException((int)ErroresGenericos.NotFoundError.HttpCode);
            }
            var personasFisicas = dbPersonasFisicas.Where(a => a.Activo == true).OrderBy(a => a.FechaRegistro);
            return Ok(personasFisicas);
        }
        [Route("api/PersonaFisica/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObtenerPersonaFisicaPorId(int id)
        {
            var personaFisica = await _service.ObtenerPorId(id);

            if (personaFisica == null)
            {
                //_logger.LogError(Constants.RESPONSE, Constants.API_NAME, "GET", "NULL");
                throw new HttpStatusCodeException((int)ErroresGenericos.NotFoundError.HttpCode);
            }
            return Ok(personaFisica);
        }
        [Route("api/PersonaFisica")]
        [HttpPost]
        public async Task<IActionResult> CrearPersonaFisica([FromBody] PersonaFisica personaFisica)
        {
            if (!ModelState.IsValid)
            {
               throw new HttpStatusCodeException((int)ErroresGenericos.NullRequestError.HttpCode);
            }
            await _service.Crear(personaFisica);

            return Created($"/api/PersonaFisica", personaFisica);
        }
        [Route("api/PersonaFisica")]
        [HttpPut]
        public async Task<IActionResult> ActualizarPersonaFisica([FromBody] PersonaFisica personaFisica)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpStatusCodeException((int)ErroresGenericos.NullRequestError.HttpCode);
            }
            await _service.Actualizar(personaFisica);

            return Ok();
        }
        //[Route("api/PersonaFisica/{id}")]
        [HttpDelete("api/PersonaFisica/{id}")]
        public async Task<IActionResult> EliminarPersonaFisica(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpStatusCodeException((int)ErroresGenericos.NullRequestError.HttpCode);
            }

            await _service.Eliminar(id);

            return Ok();
        }
    }
}
