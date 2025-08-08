using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SaiouService.api;
using SaiouService.models;
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
        [Route("{userId:long}")]
        [AsyncResourceFilter]
        public async Task<ApiResult<UserInfoData>> GetUserInfoAsync(long userId, [FromServices] IUserService userService)
        {
            // Simulate fetching user info from a service
            var userInfo = await userService.GetUserInfoAsync(userId);
            var result = await Task.FromResult(new ApiResult<UserInfoData>()
            {
                Msg = "User information retrieved successfully.",
                Data = userInfo,
                Code = 200,
                Success = true,
            });
            return result;
        }
    }
}
