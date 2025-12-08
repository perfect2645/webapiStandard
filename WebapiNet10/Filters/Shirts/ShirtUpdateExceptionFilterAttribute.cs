using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebapiNet10.Services.Shirts;

namespace WebapiNet10.Filters.Shirts
{
    public class ShirtUpdateExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IShirtService _shirtService;
        public ShirtUpdateExceptionFilterAttribute(IShirtService shirtService)
        {
            _shirtService = shirtService;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {

            if (context.RouteData.Values.TryGetValue("id", out var idObj) && idObj is int shirtId)
            {
                var shirtExists = await _shirtService.ExistsAsync(shirtId);
                if (!shirtExists)
                {
                    context.ModelState.AddModelError("id", $"Shirt with ID [{shirtId}] doesn't exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound,
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                    context.ExceptionHandled = true;
                    await base.OnExceptionAsync(context);
                    return;
                }
            }

            context.ModelState.AddModelError("Shirt", $"An unexpected error occurred while updating the shirt.");
            var unhandeledProblem = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status500InternalServerError,
            };
            context.Result = new ObjectResult(unhandeledProblem)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
            await base.OnExceptionAsync(context);
        }

    }
}
