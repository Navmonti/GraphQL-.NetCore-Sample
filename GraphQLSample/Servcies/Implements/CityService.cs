using GraphQLSample.Model.Entities;
using GraphQLSample.Repasitories.Implements;
using GraphQLSample.Servcies.Interfaces;

namespace GraphQLSample.Servcies.Implements
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
            => _cityRepository = cityRepository;
        

        public async Task<List<City>> GetAllCitiesAsync()
        {
            try
            {
                return await _cityRepository.GetAllCitiesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching cities.", ex);
            }
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            try
            {
                return await _cityRepository.GetCityByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while fetching the city with ID {id}.", ex);
            }
        }

        public async Task<City> AddCityAsync(City city)
        {
            try
            {
                return await _cityRepository.AddCityAsync(city);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the city.", ex);
            }
        }

        public async Task<City> UpdateCityAsync(int id, City city)
        {
            try
            {
                return await _cityRepository.UpdateCityAsync(id, city);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the city with ID {id}.", ex);
            }
        }

        public async Task<City> DeleteCityAsync(int id)
        {
            try
            {
                return await _cityRepository.DeleteCityAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the city with ID {id}.", ex);
            }
        }

    }
}
