using Microsoft.AspNetCore.Mvc;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello, user!");
        }
    }
}
