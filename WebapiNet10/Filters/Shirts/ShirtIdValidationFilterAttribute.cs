using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebapiNet10.Services.Shirts;

namespace WebapiNet10.Filters.Shirts
{
    public class ShirtIdValidationFilterAttribute : ActionFilterAttribute
    {
        private readonly IShirtService _shirtService;
        public ShirtIdValidationFilterAttribute(IShirtService shirtService)
        {
            _shirtService = shirtService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var shirtId = context.ActionArguments["id"] as int?;
            if (!shirtId.HasValue)
            {
                return;
            }

            if (shirtId.Value <= 0)
            {
                context.ModelState.AddModelError("id", "Shirt id must be greater than 0.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var targetShirtDto = await _shirtService.GetShirtByIdAsync(shirtId.Value);
            if (targetShirtDto == null)
            {
                context.ModelState.AddModelError("id", $"Shirt with id[{shirtId}] doesn't exist.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };

                context.Result = new NotFoundObjectResult(problemDetails);
                return;
            }
            context.HttpContext.Items.TryAdd("shirtDto", targetShirtDto);

            await next();
        }
    }
}
