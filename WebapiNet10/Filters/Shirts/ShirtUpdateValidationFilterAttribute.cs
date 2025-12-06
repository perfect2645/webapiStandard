using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebapiNet10.Models.Shirts;
using WebapiNet10.Services.Shirts;

namespace WebapiNet10.Filters.Shirts
{
    public class ShirtUpdateValidationFilterAttribute : ActionFilterAttribute
    {
        private readonly IShirtService _shirtService;
        public ShirtUpdateValidationFilterAttribute(IShirtService shirtService)
        {
            _shirtService = shirtService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var shirtId = context.ActionArguments["id"] as int?;
            var shirtDto = context.ActionArguments["updateShirtDto"] as ShirtDto;

            if (!shirtId.HasValue || shirtDto == null)
            {
                throw new ArgumentException("Shirt ID and Shirt data must be provided.");
            }

            if (shirtId.Value != shirtDto.ShirtId)
            {
                context.ModelState.AddModelError("ShirtId", "Shirt ID in the URL does not match Shirt ID in the body.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var existingShirt = await _shirtService.GetShirtByPropertiesAsync(shirtDto.Brand, shirtDto.Gender, shirtDto.Color, shirtDto.Size);
            if (existingShirt != null)
            {
                context.ModelState.AddModelError("Shirt", "A shirt with the same properties already exists.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status409Conflict,
                };
                context.Result = new ConflictObjectResult(problemDetails);
                return;
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
