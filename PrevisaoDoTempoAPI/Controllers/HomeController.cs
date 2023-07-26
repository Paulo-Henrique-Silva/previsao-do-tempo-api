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
            var cptec = new CPTECRepository();
            uint id = cptec.ObterCodigoCidadePorNomeEUF("Sao paulo", "SP").Result;
            return Ok(id);
        }
    }
}
