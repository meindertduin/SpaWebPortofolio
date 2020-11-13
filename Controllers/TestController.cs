using Microsoft.AspNetCore.Mvc;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/tests")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Test()
        {
            return "works";
        }
    }
}