using Microsoft.AspNetCore.Mvc;
using WebapiNet10.Services.Shirts;

namespace WebapiNet10.Controllers.Shirt
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    {
        private readonly ILogger<ShirtController> _logger;
        private readonly IShirtService _shirtService;
        public ShirtController(ILoggerFactory loggerFactory, IShirtService shirtService)
        {
            _logger = loggerFactory.CreateLogger<ShirtController>();
            _shirtService = shirtService;
        }

        [HttpGet("shirts")]
        public IActionResult GetAllShirts()
        {
            var shirtDtos = _shirtService.GetAllShirtsAsync();
            return Ok(shirtDtos);
        }
    }
}
