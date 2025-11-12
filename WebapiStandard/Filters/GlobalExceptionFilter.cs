using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace WebapiStandard.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IWebHostEnvironment _env; // 用于区分环境（开发/生产）

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            _logger.LogError(exception, $"Unhandled exception occurred：{exception.Message}");

            var errorResponse = new ErrorResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Server error, please try again later on."
            };

            if (_env.IsDevelopment())
            {
                errorResponse.Message = exception.Message;
                errorResponse.Detail = exception.StackTrace;
            }

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = errorResponse.StatusCode
            };

            context.ExceptionHandled = true;
            await Task.CompletedTask;
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Detail { get; set; }
    }
}
