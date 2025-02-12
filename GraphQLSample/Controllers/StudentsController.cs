using GraphQLSample.Model.Entities;
using GraphQLSample.Servcies.Implements;
using GraphQLSample.Servcies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
            => _studentService = studentService;

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                return Ok(await _studentService.GetAllStudentsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // 2. Get student by id
        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            if (id == 0)
                Problem("Id in not valid");

            try
            {
                return Ok(await _studentService.GetStudentByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 3. Add a student
        [HttpPost("students")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (student is null)
                Problem("student is null");
            try
            {
                return Ok(await _studentService.AddStudentAsync(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 4. Update a student
        [HttpPut("students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.StudentId)
                Problem("Id in not valid");

            if (student is null)
                Problem("student is null");

            try
            {
                return Ok(await _studentService.UpdateStudentAsync(id, student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 5. Delete a student
        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id == 0)
                Problem("Id in not valid");

            try
            {
                return Ok(await _studentService.DeleteStudentAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
