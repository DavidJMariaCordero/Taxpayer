using Microsoft.AspNetCore.Mvc;

namespace TaxPayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Working Get");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Working Post");

        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Working Put");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Working Delete");
        }

        [HttpPatch]
        public IActionResult Path()
        {
            return Ok("Working Patch");
        }

    }
}