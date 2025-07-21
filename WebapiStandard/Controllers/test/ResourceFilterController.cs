using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebapiStandard.Filters.test;

namespace WebapiStandard.Controllers.test
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion(3)]
    public class ResourceFilterController
    {
        private readonly ILogger<ResourceFilterController> _logger;

        public ResourceFilterController(ILogger<ResourceFilterController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("{id:int}")]
        [AsyncResourceFilter]
        public IActionResult GetAsync(int id)
        {
            _logger.LogInformation("GetAsync called with id: {Id}", id);
            return new JsonResult(
                new 
                { 
                    Id = id, 
                    Version = 3, 
                });
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResourceFilter]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Get called with id: {Id}", id);
            return new JsonResult(
                new
                {
                    Id = id,
                    Version = 3,
                });
        }
    }
}
