using GraphQLSample.Data;
using GraphQLSample.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repasitories.Implements
{
    public class CityRepository : ICityRepository
    {
        private readonly SchoolAppDbContext _context;
        public CityRepository(SchoolAppDbContext context)
            => _context = context;

        // Get all cities
        public async Task<List<City>> GetAllCitiesAsync()
          => await _context.Cities.ToListAsync();


        // Get city by Id
        public async Task<City> GetCityByIdAsync(int id)
          => await _context.Cities.FirstOrDefaultAsync(s => s.CityId == id);


        // Add a new city
        public async Task<City> AddCityAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        // Update an existing city
        public async Task<City> UpdateCityAsync(int id, City city)
        {
            var existingCity = await _context.Cities.FindAsync(id);
            if (existingCity == null) return null;

            // Update fields
            existingCity.Name = city.Name;
            existingCity.Country = city.Country;


            await _context.SaveChangesAsync();
            return existingCity;
        }

        // Delete a city
        public async Task<City> DeleteCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return null;

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return city;
        }
    }
}
