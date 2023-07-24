using Microsoft.AspNetCore.Mvc;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("/api")]
    public class PrevisoesConsultasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello");
        }
    }
}
