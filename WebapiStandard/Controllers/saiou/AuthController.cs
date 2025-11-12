using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebapiStandard.Models.Auth;
using WebapiStandard.Services.Auth;

namespace WebapiStandard.Controllers.saiou
{
    [ApiController]
    [Route("system/[controller]")]
    [ApiVersion(2.0)]
    //[Authorize]
    public class AuthController : ControllerBase
    {

        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Endpoint for user authorization.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // 使用用户服务验证凭证（实际项目应使用数据库）
            //var isValid = await _userService.ValidateCredentials(model.Username, model.Password);

            //if (!isValid)
            //    return Unauthorized("用户名或密码错误");

            var token = await _tokenService.GenerateTokenAsync(model.Username);

            return Ok(new
            {
                Msg = "Login Successfully.",
                Data = token,
                Code = 200,
                Success = true,
            });
        }
    }
}
