using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using React.Study.Dto;
using React.Study.Services;
using Utils.Generic;
using Utils.Json;
using WebapiStandard.Filters.react.Study;

namespace WebapiStandard.Controllers.react.study
{
    [ApiController]
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
        public async Task<ActionResult<IEnumerable<StudentDto>?>> GetStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(new ApiResponse<IEnumerable<StudentDto>?>(students));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError.ToInt());
            }
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(StudentIdValidationFilterAttribute))]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            HttpContext.Items.TryGetValue("student", out object? student);

            await Task.CompletedTask;
            return Ok(student as StudentDto);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto?>> CreateStudent([FromForm] CreateStudentDto studentDto)
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
