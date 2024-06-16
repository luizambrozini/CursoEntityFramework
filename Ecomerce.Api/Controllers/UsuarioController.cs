using Ecomerce.Data;
using Ecomerce.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] IUsuarioRepository usuarioRepository)
        {
            var usuarios = usuarioRepository.Get();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IUsuarioRepository usuarioRepository, int id)
        {
            var usuario = usuarioRepository.Get(id);
            if (usuario == null) return NotFound("Usuario não encontrado.");
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Add([FromServices] IUsuarioRepository usuarioRepository, [FromBody] Usuario usuario)
        {
            usuarioRepository.Add(usuario);
            return Created(string.Empty, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromServices] IUsuarioRepository usuarioRepository, [FromBody] Usuario usuario, int id)
        {
            usuario.Id = id;
            usuarioRepository.Update(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices] IUsuarioRepository usuarioRepository, int id)
        {
            usuarioRepository.Delete(id);
            return NoContent();
        }
    }
}
