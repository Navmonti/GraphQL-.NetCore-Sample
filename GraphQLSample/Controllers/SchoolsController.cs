using GraphQLSample.Model.Entities;
using GraphQLSample.Servcies.Implements;
using GraphQLSample.Servcies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        public SchoolsController(SchoolService schoolService)
            => _schoolService = schoolService;

        [HttpGet("schools")]
        public async Task<IActionResult> GetAllSchools()
        {
            try
            {
                return Ok(await _schoolService.GetAllSchoolsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // 2. Get school by id
        [HttpGet("schools/{id}")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            if (id == 0)
                Problem("Id in not valid");

            try
            {
                return Ok(await _schoolService.GetSchoolByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 3. Add a school
        [HttpPost("schools")]
        public async Task<IActionResult> AddSchool(School school)
        {
            if (school is null)
                Problem("school is null");
            try
            {
                return Ok(await _schoolService.AddSchoolAsync(school));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 4. Update a school
        [HttpPut("schools/{id}")]
        public async Task<IActionResult> UpdateSchool(int id, School school)
        {
            if (id != school.SchoolId)
                Problem("Id in not valid");

            if (school is null)
                Problem("school is null");

            try
            {
                return Ok(await _schoolService.UpdateSchoolAsync(id, school));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 5. Delete a school
        [HttpDelete("schools/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            if (id == 0)
                Problem("Id in not valid");

            try
            {
                return Ok(await _schoolService.DeleteSchoolAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
