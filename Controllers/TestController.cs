using Microsoft.AspNetCore.Mvc;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}