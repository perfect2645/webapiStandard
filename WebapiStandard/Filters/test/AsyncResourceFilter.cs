using Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebapiStandard.Filters.test
{
    public class AsyncResourceFilterAttribute : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Log4Logger.Logger.Info($"Begin OnResourceExecutionAsync.");
            await next();
            Log4Logger.Logger.Info($"End OnResourceExecutionAsync.");
        }
    }
}
