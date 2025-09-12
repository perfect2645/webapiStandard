using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using React.Study.Dto;

namespace WebapiStandard.Filters.react.Study
{
    public class StudentUpdateValidationFilterAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.ActionArguments["id"] as int?;
            var student = context.ActionArguments["studentDto"] as StudentDto;

            if (id.HasValue && student != null && id.Value != student.Id)
            {
                context.ModelState.AddModelError("StudentDto.Id", "StudentDto.Id must match id route parameter");
                var errorDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(errorDetails);
                return;
            }

            await next();
        }
    }
}
