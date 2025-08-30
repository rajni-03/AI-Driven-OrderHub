using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Server API is working!");
        }
    }
}