using buscadorWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace buscadorWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class etiquetaController : ControllerBase
    {
        private DemoConvencionesDBContext _dbContext;
        public etiquetaController(DemoConvencionesDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpGet("GetEtiquetas")]
        public IActionResult GetEtiquetas()
        {
            try
            {
                var etiquetas = _dbContext.etiquetas.ToList();
                if (etiquetas.Count == 0)
                {
                    return NotFound();
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
