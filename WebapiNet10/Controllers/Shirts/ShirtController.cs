using Microsoft.AspNetCore.Mvc;

namespace WebapiNet10.Controllers.Shirt
{
    [ApiController]
    [Route("[controller]")]
    public class ShirtController : ControllerBase
    {
        private readonly ILogger _logger;
        public ShirtController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllShirts()
        {
            return Ok("ShirtController is working!");
        }
    }
}
