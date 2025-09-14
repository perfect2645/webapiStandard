using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using React.Study.Services;
using Utils.Generic;

namespace WebapiStandard.Filters.react.Study
{
    public class StudentUpdateExceptionFilterAttribute : IAsyncExceptionFilter
    {
        private readonly IStudentService _studentService;
        public StudentUpdateExceptionFilterAttribute(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            //var strId = context.RouteData.Values["id"] as string;
            //var id = strId.ToInt();
            //if (id > 0 && !await _studentService.StudentExistsAsync(id))
            //{
            //    context.ModelState.AddModelError("StudentId", "Student doesn't exist anymore.");
            //    var problemDetails = new ValidationProblemDetails(context.ModelState)
            //    {
            //        Status = StatusCodes.Status404NotFound,
            //    };

            //    context.Result = new NotFoundObjectResult(problemDetails);
            //    return;
            //}

            context.ModelState.AddModelError("Student", context.Exception.Message);
            var problem = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
            };
            context.Result = new NotFoundObjectResult(problem);
            await Task.CompletedTask;

            context.ExceptionHandled = true;
        }
    }
}
