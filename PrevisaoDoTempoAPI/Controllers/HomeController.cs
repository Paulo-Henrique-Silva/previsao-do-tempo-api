using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempoAPI.Repositories;

namespace PrevisaoDoTempoAPI.Controllers
{
    [Controller]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello, World!");
        }
    }
}
