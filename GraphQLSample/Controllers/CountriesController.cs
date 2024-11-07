using GraphQLSample.Model.Entities;
using GraphQLSample.Servcies.Implements;
using GraphQLSample.Servcies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace GraphQLSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase  
    {
        private readonly ICountryService _countryService;
        public CountriesController(CountryService countryService)
            => _countryService = countryService;

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                return Ok(await _countryService.GetAllCountriesAsync());
            }
            catch (Exception ex)
            {
               return BadRequest(ex);
            }
            
        }

        // 2. Get country by id
        [HttpGet("countries/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            if (id == 0)
                Problem("Id in not valid");
            
            try
            {
                return Ok(await _countryService.GetCountryByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 3. Add a country
        [HttpPost("countries")]
        public async Task<IActionResult> AddCountry(Country country)
        {
            if (country is null)
                Problem("country is null");
            try
            {
                return Ok(await _countryService.AddCountryAsync(country));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            } 
        }

        // 4. Update a country
        [HttpPut("countries/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, Country country)
        {
            if (id != country.CountryId)
                Problem("Id in not valid"); 

            if (country is null)
                Problem("country is null");

            try
            {
                return Ok(await _countryService.UpdateCountryAsync(id,country));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // 5. Delete a country
        [HttpDelete("countries/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id == 0)
                Problem("Id in not valid");

            try
            {
                return Ok(await _countryService.DeleteCountryAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
