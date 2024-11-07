using GraphQLSample.Data;
using GraphQLSample.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repasitories.Implements
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id); 
        Task<City> AddCityAsync(City city);
        Task<City> UpdateCityAsync(int id, City city);
        Task<City> DeleteCityAsync(int id);
    }
}
