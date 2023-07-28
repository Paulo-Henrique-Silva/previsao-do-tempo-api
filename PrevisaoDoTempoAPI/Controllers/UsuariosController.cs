using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempoAPI.Services;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return Ok("Hello, user!");
        }
    }
}
