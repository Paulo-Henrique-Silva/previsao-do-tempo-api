using Microsoft.AspNetCore.Mvc;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("/api")]
    public class PrevisoesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello");
        }
    }
}
