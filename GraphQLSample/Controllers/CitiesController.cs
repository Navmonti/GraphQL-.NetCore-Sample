using GraphQLSample.Model.Entities;
using GraphQLSample.Servcies.Implements;
using GraphQLSample.Servcies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
            => _cityService = cityService;

        [HttpGet("cities")]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                return Ok(await _cityService.GetAllCitiesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // 2. Get city by id
        [HttpGet("cities/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            if (id == 0)
                Problem("Id in not valid");

            try
            {
                return Ok(await _cityService.GetCityByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 3. Add a city
        [HttpPost("cities")]
        public async Task<IActionResult> AddCity(City city)
        {
            if (city is null)
                Problem("city is null");
            try
            {
                return Ok(await _cityService.AddCityAsync(city));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 4. Update a city
        [HttpPut("cities/{id}")]
        public async Task<IActionResult> UpdateCity(int id, City city)
        {
            if (id != city.CityId)
                Problem("Id in not valid");

            if (city is null)
                Problem("city is null");

            try
            {
                return Ok(await _cityService.UpdateCityAsync(id, city));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 5. Delete a city
        [HttpDelete("cities/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id == 0)
                Problem("Id in not valid");

            try
            {
                return Ok(await _cityService.DeleteCityAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
