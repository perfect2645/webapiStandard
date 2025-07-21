using Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebapiStandard.Filters.test
{
    public class ResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var controllerName = context.ActionDescriptor.DisplayName;
            Log4Logger.Logger.Info($"{controllerName} OnResourceExecuted.");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var controllerName = context.ActionDescriptor.DisplayName;
            Log4Logger.Logger.Info($"{controllerName} OnResourceExecuting.");
        }
    }
}
