using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using React.Study.Dto;
using React.Study.Repositories;

namespace WebapiStandard.Filters.react.Study
{
    public class StudentUpdateValidationFilterAttribute : IAsyncActionFilter
    {
        private readonly IStudentRepository _studentRepository;
        public StudentUpdateValidationFilterAttribute(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.ActionArguments["id"] as int?;
            var student = context.ActionArguments["studentDto"] as StudentDto;

            if (!id.HasValue || student == null)
            {
                throw new ArgumentException("Invalid student");
            }

            if (id.Value != student.Id)
            {
                context.ModelState.AddModelError("StudentDto.Id", "StudentDto.Id must match id route parameter");
                var errorDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(errorDetails);
                return;
            }

            var existStudent = await _studentRepository.GetStudentByPropertiesAsync(student.Attributes.Name,
                                    student.Attributes.Age,
                                    student.Attributes.Gender,
                                    student.Attributes.Address);

            if (existStudent != null)
            {
                context.ModelState.AddModelError("Student", $"Student[{existStudent.Id}] with same attributes already exists.");
                var errorDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status409Conflict,
                };

                context.Result = new BadRequestObjectResult(errorDetails);
                return;
            }

            await next();
        }
    }
}
