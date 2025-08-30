using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using React.Study.Services;

namespace WebapiStandard.Filters.react.Study
{
    public class StudentValidationFilterAttribute: ActionFilterAttribute
    {
        private readonly IStudentService _studentService;
        public StudentValidationFilterAttribute(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
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

            if (!_studentService.StudentExists(id.Value))
            {
                context.ModelState.AddModelError("Id", "Student doesn't exist.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
