using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebapiNet10.Filters.Shirts;
using WebapiNet10.Models.Shirts;
using WebapiNet10.Models.Shirts.Validations;
using WebapiNet10.Services.Shirts;

namespace WebapiNet10.Controllers.Shirt
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    {
        private readonly ILogger<ShirtController> _logger;
        private readonly IShirtService _shirtService;

        /// <summary>
        /// Shirt Controller
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="shirtService"></param>
        public ShirtController(ILoggerFactory loggerFactory, IShirtService shirtService)
        {
            _logger = loggerFactory.CreateLogger<ShirtController>();
            _shirtService = shirtService;
        }

        /// <summary>
        /// Get all shirts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllShirtsAsync()
        {
            var shirtDtos = await _shirtService.GetAllShirtsAsync();
            return Ok(shirtDtos);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [TypeFilter(typeof(ShirtIdValidationFilterAttribute))]
        public async Task<IActionResult> GetShirtByIdAsync(int id)
        {
            var shirtDto = HttpContext.Items.TryGetValue("ShirtDto", out var dto) ? dto as ShirtDto : null;
            return await Task.FromResult(Ok(shirtDto));
        }

        /// <summary>
        /// Create a shirt
        /// </summary>
        /// <param name="createShirtDto"></param>
        /// <returns></returns>
        [HttpPost]
        [TypeFilter(typeof(ShirtCreationValidationFilterAttribute))]
        public async Task<IActionResult> CreateShirtAsync([FromBody] CreateShirtDto createShirtDto)
        {
            var shirtDto = await _shirtService.AddShirtAsync(createShirtDto);
            return CreatedAtAction(nameof(GetShirtByIdAsync),
                new { id = shirtDto.ShirtId },
                shirtDto);
        }

        /// <summary>
        /// Update a shirt
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shirtDto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [TypeFilter(typeof(ShirtIdValidationFilterAttribute))]
        [TypeFilter(typeof(ShirtUpdateValidationFilterAttribute))]
        [TypeFilter(typeof(ShirtUpdateExceptionFilterAttribute))]
        public async Task<IActionResult> UpdateShirtAsync(int id, [FromBody] ShirtDto shirtDto)
        {
            await _shirtService.UpdateShirtAsync(shirtDto);
            return NoContent();
        }

        /// <summary>
        /// Delete a shirt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [TypeFilter(typeof(ShirtIdValidationFilterAttribute))]
        public async Task<IActionResult> DeleteShirtAsync(int id)
        {
            var shirtDto = await _shirtService.DeleteShirtAsync(id);
            return Ok(shirtDto);
        }
    }
}
