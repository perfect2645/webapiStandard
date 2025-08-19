using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using React.Study.Dto;
using React.Study.Services;
using SaiouService.api;
using Utils.Generic;
using Utils.Json;

namespace WebapiStandard.Controllers.react.study
{
    [Controller]
    [Route("[controller]")]
    [ApiVersion(3.0)]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ApiResult<IEnumerable<StudentDto>>>> GetStudents()
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

                return Ok(new ApiResponse<IEnumerable<StudentDto>>(studentDtos));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError.ToInt());
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(CreateStudentDto studentDto)
        {
            var newStudent = await _studentService.CreateStudentAsync(studentDto);

            return newStudent;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<StudentDto>> DeleteStudent(int id)
        {
            var studentDto = await _studentService.DeleteStudentAsync(id);
            if (studentDto == null)
            {
                return NotFound();
            }
            return studentDto;
        }
    }
}
