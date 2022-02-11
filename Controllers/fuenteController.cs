using buscadorWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace buscadorWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class fuenteController : ControllerBase
    {
        private DemoConvencionesDBContext _dbContext;
        public fuenteController(DemoConvencionesDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpGet("GetFuentes")]
        public IActionResult GetFuentes()
        {
            try
            {
                var etiquetas = _dbContext.fuentes.ToList();
                if (etiquetas.Count == 0)
                {
                    return StatusCode(404, "No etiquetas found");
                }
                return Ok(etiquetas);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has ocurred");
            }
        }
    }
}
