using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using React.Study.Dto;
using React.Study.Services;
using Utils.Generic;

namespace WebapiStandard.Controllers.react.study
{
    [Controller]
    [Route("[controller]")]
    [ApiVersion(3.0)]
    public class StudentController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();

                var studentDtos = students.Select(s => new StudentDto
                {
                    Id = s.Id,
                    Attributes = new StudentAttributes() 
                    {
                       Name = s.Attributes.Name,
                       Age = s.Attributes.Age,
                       Gender = s.Attributes.Gender,
                       Address = s.Attributes.Address
                    }

                }).ToList();

                return new ActionResult<List<StudentDto>>(studentDtos);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError.ToInt());
            }
        }
    }
}
