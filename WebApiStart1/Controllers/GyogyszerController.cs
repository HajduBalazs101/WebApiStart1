using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiStart1.Services;
using WebApiStart1.Models;

namespace WebApiStart1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyogyszerController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAllGyogyszer()
        {
            List<Gyogyszer> gyogyszerek = new GyogyszerService().GetAllGyogyszer();
            return Ok(gyogyszerek);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            Gyogyszer result = new GyogyszerService().GetById(id);
            return Ok(result);
        }
    }
}
