 using buscadorWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace buscadorWebApi.Controllers
{
    [Route("titulo")]
    [ApiController]
    public class tituloController: ControllerBase
    {
        private DemoConvencionesDBContext _dbContext;
        public tituloController(DemoConvencionesDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpGet("GetTitulos")]
        public IActionResult GetTitulos()
        {
            try
            {
                var titulos = _dbContext.titulos.ToList();
                if (titulos.Count == 0)
                {
                    return NotFound();
                }
                return Ok(titulos);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has ocurred");
            }
        }

        [HttpGet("GetTitulo")]
        public IActionResult GetTitulo(string Titulo)
        {
            try
            {
                var entradas = _dbContext.titulos.Where(b => b.titulo.Contains(Titulo)).ToList();
                if (entradas.Count == 0)
                {
                    return NotFound();
                }
                return Ok(entradas);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has ocurred");
            }
        }
    }
}
