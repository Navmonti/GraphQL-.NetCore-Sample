using GraphQLSample.Model.Entities;
using GraphQLSample.Repasitories.Implements;
using GraphQLSample.Servcies.Interfaces;

namespace GraphQLSample.Servcies.Implements
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
            => _countryRepository = countryRepository;
     

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            try
            {
                return await _countryRepository.GetAllCountriesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException("An error occurred while fetching countries.", ex);
            }
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            try
            {
                return await _countryRepository.GetCountryByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException($"An error occurred while fetching the country with ID {id}.", ex);
            }
        }

        public async Task<Country> AddCountryAsync(Country country)
        {
            try
            {
                return await _countryRepository.AddCountryAsync(country);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException("An error occurred while adding the country.", ex);
            }
        }

        public async Task<Country> UpdateCountryAsync(int id, Country country)
        {
            try
            {
                return await _countryRepository.UpdateCountryAsync(id, country);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException($"An error occurred while updating the country with ID {id}.", ex);
            }
        }

        public async Task<Country> DeleteCountryAsync(int id)
        {
            try
            {
                return await _countryRepository.DeleteCountryAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException($"An error occurred while deleting the country with ID {id}.", ex);
            }
        }
    }
}
