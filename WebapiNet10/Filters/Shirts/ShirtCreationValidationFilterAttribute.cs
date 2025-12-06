using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebapiNet10.Services.Shirts;

namespace WebapiNet10.Filters.Shirts
{
    public class ShirtCreationValidationFilterAttribute : ActionFilterAttribute
    {
        private readonly IShirtService _shirtService;
        public ShirtCreationValidationFilterAttribute(IShirtService shirtService)
        {
            _shirtService = shirtService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var shirtCreationDto = context.ActionArguments["createShirtDto"] as Models.Shirts.CreateShirtDto;
            if (shirtCreationDto == null)
            {
                context.ModelState.AddModelError("createShirtDto", "Shirt creation data is required.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var existingShirt = await _shirtService.GetShirtByPropertiesAsync(shirtCreationDto.Brand,
                shirtCreationDto.Gender, shirtCreationDto.Color, shirtCreationDto.Size);
            if (existingShirt != null)
            {
                context.ModelState.AddModelError("createShirtDto", "A shirt with the same properties already exists.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status409Conflict,
                };
                context.Result = new ConflictObjectResult(problemDetails);
            }

            await next();
        }
    }
}
