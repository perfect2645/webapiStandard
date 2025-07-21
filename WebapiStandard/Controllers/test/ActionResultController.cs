using Asp.Versioning;
using Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiStandard.Result;

namespace WebapiStandard.Controllers.test
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion(3)]
    public class ActionResultController : ControllerBase
    {
        [HttpGet]
        public IApiResult<string> GetActionResult()
        {
            var result = new ApiStringResult
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Success",
                Data = "Hello, World!"
            };

            Log4Logger.Logger.Info($"result:{result.StatusCode}-{result.Data}");

            return result;
        }
    }
}
