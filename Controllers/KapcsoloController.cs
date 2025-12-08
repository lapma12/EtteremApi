using EtteremApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KapcsoloController : ControllerBase
    {
        private readonly IKapcsolo _kapcsolo;
        public KapcsoloController(IKapcsolo kapcsolo)
        {
            _kapcsolo = kapcsolo;
        }
        [HttpGet("GetAllKapcsolo")]
        public async Task<IActionResult> GetAllKapcsolo()
        {
            return StatusCode(201, await _kapcsolo.GetAll());
        }

    }
}
