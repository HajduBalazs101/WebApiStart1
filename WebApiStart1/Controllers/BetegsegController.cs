using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiStart1.Models;
using WebApiStart1.Services;

namespace WebApiStart1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetegsegController : ControllerBase
    {
        [HttpGet("GetAllBetegseg")]
        public IActionResult GetAllBetegseg()
        {
            try
            {
                List<Betegseg> result = new BetegsegService().GetAllBetegseg();
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Nem található adat");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Hiba történt: " + ex.Message);
            }
        }

        [HttpGet("GetByIdBetegseg/{id}")]
        public IActionResult GetByIdBetegseg(int id)
        {
            try
            {
                Betegseg result = new BetegsegService().GetById(id);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound ($"Nincs ilyen azonosítójú betegség: {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Hiba történt: " + ex.Message);
            }
        }
    }
}
