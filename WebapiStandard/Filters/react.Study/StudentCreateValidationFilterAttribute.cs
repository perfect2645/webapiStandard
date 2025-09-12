using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using React.Study.Dto;
using React.Study.Services;

namespace WebapiStandard.Filters.react.Study
{
    public class StudentCreateValidationFilterAttribute : IAsyncActionFilter
    {
        private readonly IStudentService _studentService;
        public StudentCreateValidationFilterAttribute(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var studentDto = context.ActionArguments["studentDto"] as StudentDto;
            if (studentDto == null)
            {
                context.ModelState.AddModelError("studentDto", "Student is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var existingStudent = await _studentService.GetStudentByPropertiesAsync(studentDto.Attributes.Name, 
                studentDto.Attributes.Age, 
                studentDto.Attributes.Gender,
                studentDto.Attributes.Address);

            if (existingStudent != null)
            {
                context.ModelState.AddModelError("studentDto", "Student already exists.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            await next();
        }
    }
}
