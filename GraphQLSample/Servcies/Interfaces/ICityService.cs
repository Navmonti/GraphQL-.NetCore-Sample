using GraphQLSample.Model.Entities;

namespace GraphQLSample.Servcies.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task<City> AddCityAsync(City city);
        Task<City> UpdateCityAsync(int id, City city);
        Task<City> DeleteCityAsync(int id);
    }
}
