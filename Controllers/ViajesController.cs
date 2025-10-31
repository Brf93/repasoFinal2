using Microsoft.AspNetCore.Mvc;
using repasoFinal2.DATA.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace repasoFinal2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private IViajesService _service;
        public ViajesController(IViajesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetViajes()
        {
            try
            {
                return Ok(await _service.TraerTodo());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // GET api/<ViajesController>/5
        [HttpGet("{estado}")]
        public async Task<IActionResult> GetEstado(string estado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(estado))
                {
                    return BadRequest("El estado no puede estar nulo");
                }
                return Ok(await _service.TraerEstado(estado));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ViajesController>/5
        [HttpPut("{id}/fecha")]
        public async Task<IActionResult> PutFecha(int id, [FromBody] DateOnly fecha)
        {
            try
            {
                if (id<=0)
                {
                    return BadRequest("El ID no puede ser 0");
                }
                return Ok(await _service.ModificarFecha(id,fecha));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
