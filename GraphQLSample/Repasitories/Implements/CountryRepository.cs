using GraphQLSample.Data;
using GraphQLSample.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repasitories.Implements
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SchoolAppDbContext _context;
        public CountryRepository(SchoolAppDbContext context)
            => _context = context;
       
        // Get all countrys
        public async Task<List<Country>> GetAllCountriesAsync()
          => await _context.Countries.ToListAsync();


        // Get country by Id
        public async Task<Country> GetCountryByIdAsync(int id)
          => await _context.Countries.FirstOrDefaultAsync(s => s.CountryId == id);


        // Add a new country
        public async Task<Country> AddCountryAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }

        // Update an existing country
        public async Task<Country> UpdateCountryAsync(int id, Country country)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if (existingCountry == null) return null;

            // Update fields
            existingCountry.Name = country.Name;


            await _context.SaveChangesAsync();
            return existingCountry;
        }

        // Delete a country
        public async Task<Country> DeleteCountryAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return null;

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return country;
        }
    }
}
