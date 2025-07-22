using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SaiouService.services.user;
using WebapiStandard.Filters.test;

namespace WebapiStandard.Controllers.saiou
{
    [ApiController]
    [Route("sys/userInfo")]
    [ApiVersion(2.0)]
    public class UserController : ControllerBase
    {
        public UserController() { }

        /// <summary>
        /// Endpoint to get user information by user ID.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="userService">user service</param>
        /// <returns></returns>
        [HttpGet]
        [Route("userId:long")]
        [AsyncResourceFilter]
        public async Task<IActionResult> GetUserInfoAsync(long userId, [FromServices] IUserService userService)
        {
            // Simulate fetching user info from a service
            var userInfo = userService.GetUserInfoAsync(userId);
            return await Task.FromResult(Ok(new
            {
                Msg = "User information retrieved successfully.",
                Data = userInfo,
                Code = 200,
                Success = true,
            }));
        }
    }
}
