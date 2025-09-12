using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using React.Study.Services;

namespace WebapiStandard.Filters.react.Study
{
    public class StudentIdValidationFilterAttribute: ActionFilterAttribute
    {
        private readonly IStudentService _studentService;
        public StudentIdValidationFilterAttribute(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.ActionArguments["id"] as int?;
            if (!id.HasValue)
            {
                return;
            }

            if (id.Value <= 0)
            {
                context.ModelState.AddModelError("Id", "StudentId is invalid.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
            {
                context.ModelState.AddModelError("Id", "Student doesn't exist.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            context.HttpContext.Items.TryAdd("student", student);

            await next();
        }
    }
}
