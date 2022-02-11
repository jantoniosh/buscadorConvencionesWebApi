using buscadorWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace buscadorWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class entradaController : ControllerBase
    {
        private DemoConvencionesDBContext _dbContext;
        public entradaController(DemoConvencionesDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpGet("GetEntradas")]
        public IActionResult GetEntradas()
        {
            try
            {
                var entradas = _dbContext.entradas.ToList();
                if (entradas.Count == 0)
                {
                    return NotFound();
                }
                return Ok(entradas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("GetEntrada")]
        public IActionResult GetEntrada(string slug)
        {
            try
            {
                var entrada = _dbContext.entradas.Where(b => b.url.Equals(slug)).FirstOrDefault();
                if (entrada == null)
                {
                    return NotFound();
                }
                return Ok(entrada);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has ocurred");
            }
        }

        [HttpGet("GetBusqueda")]
        public IActionResult GetBusqueda(string texto)
        {
            try
            {
                var entradas = _dbContext.entradas.Where(b => b.titulo.Contains(texto) || b.subtitulo.Contains(texto) || b.subsubtitulo.Contains(texto)).ToList();
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

        [HttpGet("GetEtiqueta")]
        public IActionResult GetEtiqueta(string etiqueta)
        {
            try
            {
                var entradas = _dbContext.entradas.Where(b => b.etiquetas.Contains(etiqueta)).ToList();
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
